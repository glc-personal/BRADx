using Logging;

namespace Controllers;

public class Controller : ControllerBase
{
    public Controller(string name, ILogger logger, string configFilePath) : base(name, logger, configFilePath)
    {
    }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}