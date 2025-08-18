using Configurations.Helpers;

namespace Configurations.Providers;

public class AppSettingsConfigProvider : IAppSettingsConfigProvider
{
    public async Task<IDictionary<string, IControllerConfig>> GetConfigsAsync(AppSettingsConfigFilesOptions options, CancellationToken cancellationToken = default)
    {
        var result = new Dictionary<string, IControllerConfig>(StringComparer.OrdinalIgnoreCase);
        var configsPath = options.Directory;
        if (!Directory.Exists(configsPath))
            throw new DirectoryNotFoundException($"Directory {configsPath} not found");
        var prefix = options.Prefix;
        var paths = Directory.EnumerateFiles(configsPath, $"{prefix}.*.xml", SearchOption.TopDirectoryOnly);
        
        foreach (var path in paths)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var controllerConfig = new ControllerConfig();
            controllerConfig = ControllerConfigXmlLoader.Load(path);
            var controllerName = controllerConfig.Name;
            result.Add(controllerName, controllerConfig);
        }
        
        return result;
    }
}