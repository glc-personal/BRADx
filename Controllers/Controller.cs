using Communications.Configuration;
using Configurations;
using Logging;

namespace Controllers;

public class Controller : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IControllerConfig _config;
    
    public Controller(ILogger logger, IControllerConfig config) : base(logger, config)
    {
        _logger = logger;
        _config = config;
    }
}