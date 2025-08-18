namespace Configurations;

public interface IHardwareConfig
{
    #region Attributes
    string Name { get; }
    #endregion
    
    string DisplayName { get; }
    bool Simulate { get; }
    ICommunicationConfig Communication { get; }
    IReadOnlyDictionary<string, string> Defaults { get; }
}