using Communications.Enums;

namespace Configurations;

public class SharedSerialCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.SharedSerial;

    public string ComPort { get; init; } = "";
    public int? BaudRate { get; init; }
    public int Address { get; init; }
}