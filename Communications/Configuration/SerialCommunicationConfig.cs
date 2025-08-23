using Communications.Enums;

namespace Communications.Configuration;

public class SerialCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.Serial;
    public string ComPort { get; init; } = "";
    public int BaudRate { get; init; }
}