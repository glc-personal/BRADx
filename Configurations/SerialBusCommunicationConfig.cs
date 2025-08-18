using Communications.Enums;

namespace Configurations;

public class SerialBusCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.SerialBus;

    public string ComPort { get; init; } = "";
    public int? BaudRate { get; init; }
    public int Address { get; init; }
}