using Communications;
using Configurations;

namespace MagSeparator;

public class MagSeparator : IMagSeparator
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public MagSeparator(IHardwareConfig config, ICommunicationChannel commChannel)
    {
        _config = config;
        _commChannel = commChannel;
    }
    
    public string Name => _config.Name;
    
    public void Initialize()
    {
        throw new NotImplementedException();
    }
}