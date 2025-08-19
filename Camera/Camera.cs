using Communications;
using Configurations;

namespace Camera;

public class Camera : ICamera
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public Camera(IHardwareConfig config, ICommunicationChannel commChannel)
    {
        _config = config;
        _commChannel = commChannel;
    }
    
    public string Name => _config.Name;

    public void Initialize()
    {
        throw new NotImplementedException();
    }

    public void SnapImage()
    {
        throw new NotImplementedException();
    }
}