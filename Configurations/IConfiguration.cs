namespace Configurations;

public interface IConfiguration
{
    IDictionary<string, object> Settings { get; set; }
    string FilePath { get; }
}