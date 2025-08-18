using Logging.Enums;

namespace Logging;

public interface ILogger
{
    void Log(Object sender, LogLevels level, string message);
}