namespace Configurations;

public interface IControllerConfig
{
    #region Attributes
    string Name { get; }
    string Description { get; }
    #endregion
    
    string DisplayName { get; }
    IReadOnlyList<IControllerConfig> Children { get; }
    IReadOnlyList<IHardwareConfig> Hardware { get; }
}