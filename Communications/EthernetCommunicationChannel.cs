using Communications.Configuration;
using Communications.Enums;

namespace Communications;

public class EthernetCommunicationChannel : ICommunicationChannel
{
    private EthernetCommunicationConfig _config;
    private bool _simulated;

    public EthernetCommunicationChannel(EthernetCommunicationConfig config, bool simulated = false)
    {
        _config = config;
        _simulated = simulated;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public CommunicationTypes Type => CommunicationTypes.Ethernet;
    public bool Simulated => _simulated;
    public void Send(object data)
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(object data)
    {
        throw new NotImplementedException();
    }
}