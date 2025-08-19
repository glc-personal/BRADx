using Communications;
using Configurations;

namespace PreAmpThermocycler;

public class PreAmpThermocycler : IPreAmpThermocycler
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public PreAmpThermocycler(IHardwareConfig config, ICommunicationChannel channel)
    {
        _config = config;
        _commChannel = channel;
    }
    
    public string Name => _config.Name;
    
    public void Initialize()
    {
        throw new NotImplementedException();
    }
}