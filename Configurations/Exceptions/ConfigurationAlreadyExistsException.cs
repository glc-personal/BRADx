namespace Configurations.Exceptions;

public class ConfigurationAlreadyExistsException : Exception
{
    private string _configOwnerName;

    public ConfigurationAlreadyExistsException(string configOwnerName)
    {
        _configOwnerName = configOwnerName;
    }
    
    public override string Message => $"Configuration already exists for {_configOwnerName}.";
}