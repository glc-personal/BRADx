using Communications.Enums;

namespace Communications.Configuration;

public interface ICommunicationConfig
{
    #region Attributes
    CommunicationTypes Type { get; }
    #endregion
    
}