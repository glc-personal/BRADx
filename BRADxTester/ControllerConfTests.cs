using System.Xml.Linq;
using Configurations;
using Configurations.Helpers;

namespace BRADxTester;

public class ControllerConfTests
{
    IControllerConfig _controllerConfig;
    
    [SetUp]
    public void Setup()
    {
        _controllerConfig = new ControllerConfig();
    }

    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\InstrumentControlService\\configs\\ics.deck.config.xml")]
    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\InstrumentControlService\\configs\\ics.reader.config.xml")]
    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\InstrumentControlService\\configs\\ics.robot.config.xml")]
    public void LoadControllerConfigTest(string configConfigPath)
    {
        try
        {
            var controllerConfig = ControllerConfigLoader.Load(configConfigPath);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\InstrumentControlService\\configs\\ics.deck.config.xml")]
    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\InstrumentControlService\\configs\\ics.reader.config.xml")]
    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\InstrumentControlService\\configs\\ics.robot.config.xml")]
    public void VerifyLoadedControllerConfigRootTest(string configConfigPath)
    {
        try
        {
            var controllerConfig = ControllerConfigLoader.Load(configConfigPath);
            
            // verify a few things
            var controllerName = controllerConfig.Name;
            var controllerDescription = controllerConfig.Description;
            var controllerDisplayName = controllerConfig.DisplayName;
            
            var xmlDoc = XDocument.Load(configConfigPath);
            var root = xmlDoc.Root;
            if (root != null)
            {
                var name = root.Attribute("name")?.Value;
                Assert.That(name, Is.EqualTo(controllerName));
                var description = root.Attribute("description")?.Value;
                Assert.That(description, Is.EqualTo(controllerDescription));
                var displayName = root.Element("displayName")?.Value;
                if (displayName != null)
                {
                    Assert.That(displayName, Is.EqualTo(controllerDisplayName));
                }
            }
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
}