using System.Xml.Linq;
using Communications.Configuration;
using Configurations.Exceptions;

namespace Configurations.Helpers;

public static class ControllerConfigLoader
{
    public static ControllerConfig Load(string configPath)
    {
        var doc = XDocument.Load(configPath);
        var root = doc.Root ?? throw new InvalidOperationException($"Empty config: {configPath}");

        if (root.Name.LocalName != "controller")
            throw new ConfigParseException($"Invalid controller config, root must be <controller>: {configPath}", root);

        return ParseController(root);
    }

    private static ControllerConfig ParseController(XElement controllerElement)
    {
        var config = new ControllerConfig
        {
            Name = RequiredAttribute(controllerElement, "name"),
            Description = RequiredAttribute(controllerElement, "description"),
            DisplayName = RequiredChildText(controllerElement, "displayName"),
        };
        
        // children
        if (controllerElement.Elements("child").Any())
        {
            foreach (var childEl in controllerElement.Elements("child"))
            {
                var childCtrl = new XElement("controller",
                    new XAttribute("name", RequiredAttribute(childEl, "name")),
                    new XAttribute("description", RequiredAttribute(childEl, "description")),
                    childEl.Elements()); // reuse inner structure (displayName, hardware, etc.)
                
                config.ChildrenMutable.Add(ParseController(childCtrl));
            }
        }
        
        // hardware
        foreach (var hardwareEl in controllerElement.Elements("hardware"))
            config.HardwareMutable.Add(ParseHardware(hardwareEl));
        
        return config;
    }

    private static string RequiredAttribute(XElement el, string attributeName) 
        => (string?)el?.Attribute(attributeName) ?? throw new ConfigParseException($"Missing attribute {attributeName} on <{el.Name.LocalName}>", el);

    private static string RequiredChildText(XElement parent, string childName)
    {
        if (parent.Element(childName) == null) throw new ConfigParseException($"Missing child <{childName}> under {parent}", parent);
        var child = parent.Element(childName)
            ?? throw new ConfigParseException($"Missing child <{childName}> under <{parent?.Name.LocalName} {parent.Attribute("type")}> under <{parent.Parent.Name.LocalName} {parent.Parent.Attribute("name")}>", parent!);

        var value = child?.Value.Trim();
        if (string.IsNullOrEmpty(value))
            throw new ConfigParseException($"Empty child <{childName}> under <{parent?.Name.LocalName}>", parent!);
        return value;
    }

    private static HardwareConfig ParseHardware(XElement element)
    {
        var hardware = new HardwareConfig
        {
            Name = RequiredAttribute(element, "name"),
            DisplayName = RequiredChildText(element, "displayName"),
            Simulate = bool.Parse(RequiredChildText(element, "simulate"))
        };
        
        // communication
        var communicationElement = element.Element("communication") ?? throw new InvalidOperationException($"Missing communication element <{element.Name.LocalName}>");
        hardware.Communication = ParseCommunication(communicationElement);
        
        // defaults
        var defaultsElement = element.Elements("defaults").FirstOrDefault();
        if (defaultsElement != null)
        {
            foreach (var defaultElement in defaultsElement.Elements())
                hardware.DefaultsMutable[defaultElement.Name.LocalName] = defaultElement.Value.Trim();
        }
        
        return hardware;
    }

    private static ICommunicationConfig ParseCommunication(XElement element)
    {
        var typeStr = RequiredAttribute(element, "type").Trim();

        return typeStr switch
        {
            // TODO: Use the CommunicationTypes enum for this...
            "usb" => new UsbCommunicationConfig(),
            "serial" => new SerialCommunicationConfig
            {
                ComPort = RequiredChildText(element, "comPort"),
                BaudRate = OptionalChildInt(element, "baudRate"),
            },
            "serialBus" => new SerialBusCommunicationConfig
            {
                ComPort = RequiredChildText(element, "comPort"),
                Address = RequiredChildInt(element, "address"),
                BaudRate = OptionalChildInt(element, "baudRate"),
            },
            "ethernet" => new EthernetCommunicationConfig
            {
                IpAddress = RequiredChildText(element, "ipAddress"),
            }, 
            _ => throw new InvalidOperationException($"Unknown communication type {typeStr}")
        };
    }

    private static int RequiredChildInt(XElement parent, string childName)
    {
        var el = parent.Element(childName);
        if (el == null) throw new ConfigParseException($"Missing child <{childName}> under <{parent?.Name.LocalName} {parent?.Attribute("type")} under {parent.Parent.Name.LocalName} {parent.Parent.Attribute("name")}>", parent);
        return int.TryParse(el.Value.Trim(), out var v) ? v : throw new InvalidOperationException($"Invalid child <{childName}> under <{parent?.Name.LocalName} type='{parent?.Attribute("type")}'>");
    }

    private static int? OptionalChildInt(XElement parent, string childName)
    {
        var el = parent.Element(childName);
        if (el == null) return null;
        return int.TryParse(el?.Value.Trim(), out var v) ? v : null;
    }
}