using Communications.Enums;

namespace Configurations;

public interface ICommunicationConfig
{
    #region Attributes
    CommunicationTypes Type { get; }
    #endregion
    
}