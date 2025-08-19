using Communications;
using Configurations;
using Core;
using Logging;
using Logging.Enums;

namespace Factories;

public class HardwareFactory : IHardwareFactory
{
    private readonly ILogger _logger;
    private IDictionary<string, Func<IHardware>> _registry;

    public HardwareFactory(ILogger logger)
    {
        _logger = logger;
        _registry = new Dictionary<string, Func<IHardware>>();
    }

    public HardwareFactory Register(string hardwareName, Func<IHardware> hardware)
    {
        if (!_registry.ContainsKey(hardwareName))
            _registry.Add(hardwareName, hardware);
        return this;
    }

    public IHardware Build(IHardwareConfig config)
    {
        if (!_registry.TryGetValue(config.Name, out var hardware))
            _logger.Log(this, LogLevels.Warning, $"Hardware {config.Name} not found");
            //throw new KeyNotFoundException($"Hardware {config.Name} not found");
        var hw = hardware();
        return hw;
    }
}