using Configurations.Exceptions;

namespace Configurations.Helpers;

public static class ConfigurationHelper
{
    /// <summary>
    /// Grab local system configurations
    /// </summary>
    /// <returns></returns>
    public static IDictionary<string, string> GetLocalConfigurationFilePaths(string path)
    {
        var paths = new Dictionary<string, string>();
        
        foreach (var filePath in Directory.GetFiles(path))
        {
            var filePathWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            var moduleName = GetModuleNameFromConfigFilePath(filePathWithoutExtension);
            if (paths.ContainsKey(moduleName))
                throw new ConfigurationAlreadyExistsException(moduleName);
            paths.Add(moduleName, filePath);
        }
        
        return paths;
    }

    private static string GetModuleNameFromConfigFilePath(string configFilePath, string prefix = "", string suffix = ".config")
    {
        var fileName = Path.GetFileNameWithoutExtension(configFilePath);
        var moduleName = fileName.Replace(prefix, string.Empty).Replace(suffix, string.Empty);
        return moduleName;
    }
}