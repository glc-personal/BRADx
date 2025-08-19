using Communications;
using Communications.Configuration;
using Configurations;

namespace Chiller;

public class Chiller : IChiller
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public Chiller(IHardwareConfig config, ICommunicationChannel channel)
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