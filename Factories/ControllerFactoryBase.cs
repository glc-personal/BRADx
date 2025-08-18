using System.Collections;
using Controllers;
using Core;
using Logging;

namespace Factories;

public abstract class ControllerFactoryBase : IControllerFactory
{
    private readonly ILogger _logger;
    private readonly string _configFilePath;
    
    public ControllerFactoryBase(ILogger logger, string configFilePath)
    {
        _logger = logger;
        _configFilePath = configFilePath;
    }
    
    public virtual ControllerBase Build(string name, ICollection<IController>? controllers = null, ICollection<IHardware>? hardware = null)
    {
        var controller = new Controller(name, _logger, _configFilePath);
        
        foreach (var c in controllers ?? new List<IController>())
            controller.AddChild(c);
        foreach (var h in hardware ?? new List<IHardware>())
            controller.AddHardware(h);
        
        return controller;
    }
}