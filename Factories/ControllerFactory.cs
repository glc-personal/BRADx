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
        var hardwareFactory = new HardwareFactory(_logger)
            .Register("camera", ()
                => new Camera.Camera())
            .Register("preAmpThermocycler", ()
                => new PreAmpThermocycler.PreAmpThermocycler())
            .Register("chiller", ()
                => new Chiller.Chiller())
            .Register("heaterShaker", ()
                => new HeaterShaker.HeaterShaker())
            .Register("magSeparator", ()
                => new MagSeparator.MagSeparator())
            .Register("rotationalMotor", ()
                => new RotationalMotor())
            .Register("linearMotor", ()
                => new LinearMotor())
            .Register("ledBoard", ()
                => new LedBoard.LedBoard())
            .Register("valveBoard", () 
                => new ValveBoard.ValveBoard())
            .Register("pipetteHead", ()
                => new PipetteHead.PipetteHead());
        foreach (var hwConfigKvp in hwConfigsDict)
        {
            var hw = hardwareFactory.Build(hwConfigKvp.Value);
            controller.AddHardware(hw);
        }
        
        return controller;
    }
}