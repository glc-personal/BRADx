using System.Xml;

namespace Configurations;

public interface IConfigurable
{ 
    IConfiguration? Config { get; }
    event EventHandler<IConfigurable> OnConfigurationChanged;
    void Configure(XmlDocument configuration);
}