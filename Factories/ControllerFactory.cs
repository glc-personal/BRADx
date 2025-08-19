using Configurations;
using Configurations.Helpers;
using Controllers;
using Logging;
using Motor;

namespace Factories;

public class ControllerFactory : IControllerFactory
{
    private readonly ILogger _logger;

    public ControllerFactory(ILogger logger)
    {
        _logger = logger;
    }
    
    public IController Build(IControllerConfig config)
    {
        var controller = new Controller(_logger, config);
        
        // build the children
        var childrenConfigs = ControllerConfigTool.GetChildrenConfigs(config);
        var childControllerFactory = new ControllerFactory(_logger);
        if (childrenConfigs.Any())
        {
            foreach (var childConfig in childrenConfigs)
            {
                var childController = childControllerFactory.Build(childConfig);
                controller.AddChild(childController);
            }
        }
        
        // build the hardware
        var hwConfigsDict = ControllerConfigTool.GetHardwareConfigs(config);
        var commChannelFactory = new CommunicationChannelFactory();
        var hardwareFactory = new HardwareFactory(_logger)
            .Register("camera", ()
                => new Camera.Camera(hwConfigsDict["camera"],
                    commChannelFactory.Build(hwConfigsDict["camera"].Communication,
                        hwConfigsDict["camera"].Simulate)))
            .Register("preAmpThermocycler", ()
                => new PreAmpThermocycler.PreAmpThermocycler(hwConfigsDict["preAmpThermocycler"],
                    commChannelFactory.Build(hwConfigsDict["preAmpThermocycler"].Communication,
                        hwConfigsDict["preAmpThermocycler"].Simulate)))
            .Register("chiller", () 
                => new Chiller.Chiller(hwConfigsDict["chiller"],
                    commChannelFactory.Build(hwConfigsDict["chiller"].Communication, 
                        hwConfigsDict["chiller"].Simulate)))
            .Register("heaterShaker", () 
                => new HeaterShaker.HeaterShaker(hwConfigsDict["heaterShaker"],
                    commChannelFactory.Build(hwConfigsDict["heaterShaker"].Communication, 
                        hwConfigsDict["heaterShaker"].Simulate)))
            .Register("magSeparator", ()
                => new MagSeparator.MagSeparator(hwConfigsDict["magSeparator"],
                    commChannelFactory.Build(hwConfigsDict["magSeparator"].Communication, 
                        hwConfigsDict["magSeparator"].Simulate)))
            .Register("rotationalMotor", ()
                => new RotationalMotor(hwConfigsDict["rotationalMotor"],
                    commChannelFactory.Build(hwConfigsDict["rotationalMotor"].Communication, 
                        hwConfigsDict["rotationalMotor"].Simulate)))
            .Register("linearMotor", ()
                => new RotationalMotor(hwConfigsDict["linearMotor"],
                    commChannelFactory.Build(hwConfigsDict["linearMotor"].Communication, 
                        hwConfigsDict["linearMotor"].Simulate)))
            .Register("ledBoard", () 
                => new LedBoard.LedBoard(hwConfigsDict["ledBoard"],
                    commChannelFactory.Build(hwConfigsDict["ledBoard"].Communication, 
                        hwConfigsDict["ledBoard"].Simulate)));
        foreach (var hwConfigKvp in hwConfigsDict)
        {
            var hw = hardwareFactory.Build(hwConfigKvp.Value);
            controller.AddHardware(hw);
        }
        
        return controller;
    }
}