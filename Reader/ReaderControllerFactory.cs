using Camera;
using Controllers;
using Core;
using Factories;
using Logging;

namespace Reader;

public class ReaderControllerFactory : ControllerFactoryBase
{
    private readonly ILogger _logger;
    private readonly string _configFilePath;

    public ReaderControllerFactory(ILogger logger, string configFilePath) : base(logger, configFilePath)
    {
        _logger = logger;
        _configFilePath = configFilePath;
    }
    
    public override ControllerBase Build(string name, ICollection<IController>? controllers = null, ICollection<IHardware>? hardware = null)
    {
        var controller = new Controller(name, _logger, _configFilePath);
        
        // build the image module
        var imagerFactory = new ControllerFactory(_logger, _configFilePath);
        var cameraFactory = new CameraFactory(_logger);
        var imager = imagerFactory.Build("Imager",
            null,
            new List<IHardware>
            {
                cameraFactory.Build(true, "Teledyne FLIR Sim")
            });
        
        // build the gantry module
        var gantryFactory = new ControllerFactory(_logger, _configFilePath);
        
        // add controllers and hardware to the reader module
        controller.AddChild(imager);
        
        return controller;
    }
}