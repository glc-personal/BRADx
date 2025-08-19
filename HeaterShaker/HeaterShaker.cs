using Communications;
using Configurations;

namespace HeaterShaker;

public class HeaterShaker : IHeaterShaker
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public HeaterShaker(IHardwareConfig config, ICommunicationChannel channel)
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