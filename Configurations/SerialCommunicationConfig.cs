using Communications.Enums;

namespace Configurations;

public class SerialCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.Serial;
    public string ComPort { get; init; } = "";
    public int? BaudRate { get; init; }
}