using Communications.Configuration;
using Communications.Enums;

namespace Communications;

public class ApiCommunicationChannel : ICommunicationChannel
{
    private ApiCommunicationConfig _config;
    private bool _simulated;

    public ApiCommunicationChannel(ApiCommunicationConfig config, bool simulated = false)
    {
        _config = config;
        _simulated = simulated;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public CommunicationTypes Type => CommunicationTypes.Api;
    public bool Simulated => _simulated;
    public void Send(object data)
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(object data)
    {
        throw new NotImplementedException();
    }

    public void Connect()
    {
        return;
    }

    public void Disconnect()
    {
        return;
    }
}