namespace Configurations;

public class Configuration : IConfiguration
{
    private IDictionary<string, object> _settings;
    private string _filePath;

    public Configuration(string filePath)
    {
        _settings = new Dictionary<string, object>();
        _filePath = filePath;
    }

    public IDictionary<string, object> Settings { get => _settings; set => _settings = value; }
    
    public string FilePath => _filePath;
}