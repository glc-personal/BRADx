using Communications.Configuration;
using Communications.Enums;

namespace Communications;

public class SerialCommunicationChannel : ICommunicationChannel
{
    private SerialCommunicationConfig _config;
    private bool _simulated;

    public SerialCommunicationChannel(SerialCommunicationConfig config, bool simulated = false)
    {
        _config = config;
        _simulated = simulated;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public CommunicationTypes Type => CommunicationTypes.Serial;
    public bool Simulated => _simulated;
}