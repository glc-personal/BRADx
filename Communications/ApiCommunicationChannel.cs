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
}