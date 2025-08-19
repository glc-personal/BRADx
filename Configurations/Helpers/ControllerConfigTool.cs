namespace Configurations.Helpers;

public static class ControllerConfigTool
{
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