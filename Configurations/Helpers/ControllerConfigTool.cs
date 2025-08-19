namespace Configurations.Helpers;

public static class ControllerConfigTool
{
    public static ICollection<IControllerConfig> GetChildrenConfigs(IControllerConfig controllerConfig)
    {
        var childrenConfigs = new List<IControllerConfig>();
        foreach (var childConfig in controllerConfig.Children)
            childrenConfigs.Add(childConfig);
        return childrenConfigs;
    }

    public static IDictionary<string, IHardwareConfig> GetHardwareConfigs(IControllerConfig controllerConfig)
    {
        int i = 1; // increment if there is multiple of the same type of hardware in the controller
        var hardwareConfigs = new Dictionary<string, IHardwareConfig>();
        foreach (var hardwareConfig in controllerConfig.Hardware)
        {
            var hardwareName = hardwareConfig.Name;
            if (hardwareConfigs.ContainsKey(hardwareName))
                hardwareName += $"_{i++}";
            hardwareConfigs.Add(hardwareName, hardwareConfig);
        }
        return hardwareConfigs;
    }

    public static ICollection<string> GetChildrenNames(IControllerConfig controllerConfig)
    {
        var names = new List<string>();
        foreach (var child in controllerConfig.Children)
            names.Add(child.Name);
        return names;
    }

    public static ICollection<string> GetHardwareNames(IControllerConfig controllerConfig)
    {
        var names = new List<string>();
        foreach (var hardware in controllerConfig.Hardware)
            names.Add(hardware.Name);
        return names;
    }
}