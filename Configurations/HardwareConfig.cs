using Communications.Configuration;

namespace Configurations;

public class HardwareConfig : IHardwareConfig
{
    public string Name { get; init; } = "";
    public string DisplayName { get; init; } = "";
    public bool Simulate { get; init; }
    public ICommunicationConfig Communication { get; set; }
    public Dictionary<string, string> DefaultsMutable { get; } = new();
    public IReadOnlyDictionary<string, string> Defaults => DefaultsMutable;
}