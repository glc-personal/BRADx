using Communications;
using Configurations;

namespace Motor;

public class RotationalMotor : IMotor
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public RotationalMotor(IHardwareConfig config, ICommunicationChannel channel)
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