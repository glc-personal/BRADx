namespace Configurations.Exceptions;

public class InvalidConfigurationException : InvalidCastException
{
    public override string Message => $"Invalid configuration:";
}