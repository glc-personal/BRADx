using Logging;

namespace Factories;

public class ControllerFactory : ControllerFactoryBase
{
    public ControllerFactory(ILogger logger, string configFilePath) : base(logger, configFilePath)
    {
    }
}