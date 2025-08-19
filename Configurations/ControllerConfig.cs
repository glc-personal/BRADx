using Communications.Configuration;

namespace Configurations;

public class ControllerConfig : IControllerConfig
{
    public string Name { get; init; } = "";
    public string Description { get; init; } = "";
    public string DisplayName { get; init; } = "";
    public List<ControllerConfig> ChildrenMutable { get; } = new();
    public IReadOnlyList<IControllerConfig> Children => ChildrenMutable;
    public List<HardwareConfig> HardwareMutable { get; } = new();
    public IReadOnlyList<IHardwareConfig> Hardware => HardwareMutable;
}