using Communications;
using Communications.Configuration;
using Configurations;

namespace Factories;

public class CommunicationChannelFactory : ICommunicationChannelFactory
{
    private readonly Dictionary<string, ICommunicationChannel> _serialBusPool = new(StringComparer.OrdinalIgnoreCase); 
    
    public ICommunicationChannel Build(ICommunicationConfig config, bool simulated)
    {
        return config switch
        {
            UsbCommunicationConfig usbConfig => new UsbCommunicationChannel(usbConfig, simulated),
            SerialCommunicationConfig serialConfig => new SerialCommunicationChannel(serialConfig, simulated),
            SerialBusCommunicationConfig serialBusConfig => BuildOrGetBusChannel(serialBusConfig, simulated),
            EthernetCommunicationConfig ethernetConfig => new EthernetCommunicationChannel(ethernetConfig, simulated),
            ApiCommunicationConfig apiConfig => new ApiCommunicationChannel(apiConfig, simulated),
            _ => throw new NotSupportedException()
        };
    }

    private ICommunicationChannel BuildOrGetBusChannel(SerialBusCommunicationConfig config, bool simulated)
    {
        if (!_serialBusPool.TryGetValue(config.ComPort, out var channel))
        {
            channel = new SerialBusCommunicationChannel(config, simulated);
            _serialBusPool.Add(config.ComPort, channel);
        }
        return channel;
    }
}