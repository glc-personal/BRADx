using Communications.Enums;

namespace Configurations;

public class EthernetCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.Ethernet;
    public string IpAddress { get; init; } = "127.0.0.1"; 
}