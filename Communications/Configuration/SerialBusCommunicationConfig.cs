using Communications.Enums;

namespace Communications.Configuration;

public class SerialBusCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.SerialBus;

    public string ComPort { get; init; } = "";
    public int? BaudRate { get; init; }
    public int Address { get; init; }
}