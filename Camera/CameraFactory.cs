using Communications;
using Core;
using Factories;
using Logging;

namespace Camera;

public class CameraFactory : IHardwareFactory
{
    private readonly ILogger _logger;
    
    public CameraFactory(ILogger logger)
    {
        _logger = logger;
    }
    
    public IHardware Build(bool simulateHardware, string name)
    {
        if (simulateHardware)
        {
            var camera = new CameraSim(new SerialCommunicationSim(_logger, ""), name);
            return camera;
        }
        
        throw new NotImplementedException("Unknown camera type");
    }
}