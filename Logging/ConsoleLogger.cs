using System.Text;
using Logging.Enums;

namespace Logging;

public class ConsoleLogger : ILogger
{
    public void Log(object sender, LogLevels level, string message)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"[{DateTime.Now.ToString("O")}]");
        stringBuilder.Append($" - {sender.GetType().Name}");
        stringBuilder.Append($" - [{level.ToString()}]");
        stringBuilder.AppendLine($": {message}");
        Console.WriteLine(stringBuilder.ToString());
    }
}