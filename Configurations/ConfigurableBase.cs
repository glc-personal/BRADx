using System.Xml;
using Configurations.Exceptions;
using Logging;
using Logging.Enums;
using IO.Converters;

namespace Configurations;

public abstract class ConfigurableBase : IConfigurable
{
    private readonly object _lock = new();
    private readonly ILogger _logger;
    private IConfiguration _config;

    public ConfigurableBase(ILogger logger, string configFilePath)
    {
        _logger = logger;
        _config = new Configuration(configFilePath);
        SetupInitialConfig();
    }

    public IConfiguration Config
    {
        get
        {
            lock (_lock)
                return _config;
        }
    }
    
    public event EventHandler<IConfigurable>? OnConfigurationChanged;

    public void Configure(XmlDocument configuration)
    {
        if (configuration is null) throw new ArgumentNullException(nameof(configuration));
        if (configuration.DocumentElement is null) throw new NullReferenceException(nameof(configuration.DocumentElement));

        lock (_lock)
        {
            var root = configuration.DocumentElement;
            SetupConfigFromXml(root, _config);
        }

        try
        {
            Validate();
        }
        catch (InvalidConfigurationException ex)
        {
            _logger.Log(this, LogLevels.Error, ex.Message);
        }
    }
    
    public abstract void Validate();
    
    #region Helpers

    private void SetupInitialConfig()
    {
        _logger.Log(this, LogLevels.Info, "Initializing configuration");
        if (!File.Exists(_config.FilePath))
        {
            _logger.Log(this, LogLevels.Error, "Configuration file does not exist");
            return;
        }
        var fs = File.Open(_config.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        var converter = new XmlFileToXmlDocumentConverter();
        Configure(converter.Convert(fs));
    }

    private static void SetupConfigFromXml(XmlElement root, IConfiguration config)
    {
        // Flattens as "path.to.node" and "path.to.node@attr"
        // Node text goes under the node key if it has inner text
        // Multiple same-name children get numeric suffixes: "exampleNode.childNode[0].element"
        void Walk(XmlNode node, string path)
        {
            if (node is XmlElement ele)
            {
                // attributes
                if (ele.HasAttributes)
                {
                    foreach (XmlAttribute attr in ele.Attributes)
                    {
                        var key = string.IsNullOrEmpty(attr.Name) ? $"@{attr.Name}" : $"{path}@{attr.Name}";
                        config.Settings[key] = attr.Value;
                    }
                }
                
                // element text 
                var text = ele.InnerText?.Trim();
                if (!string.IsNullOrEmpty(text) && !ele.ChildNodes.OfType<XmlElement>().Any())
                {
                    var key = path;
                    if (!string.IsNullOrEmpty(key))
                        config.Settings[key] = text!;
                }
                
                // children with index for repeated siblings
                var groups = ele.ChildNodes
                    .OfType<XmlElement>()
                    .GroupBy(x => x.Name);

                foreach (var group in groups)
                {
                    var list = group.ToList();
                    bool needsIndex = list.Count > 1;

                    for (int i = 0; i < list.Count; i++)
                    {
                        var child = list[i];
                        var childKey = string.IsNullOrEmpty(path) ? child.Name : $"{path}.{child.Name}";
                        if (needsIndex)
                            childKey += $"[{i}]";
                        Walk(child, childKey);
                    }
                }
            }
        }
        
        Walk(root, root.Name);
    }
    
    #endregion
}