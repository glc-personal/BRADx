using System.Xml.Linq;
using Configurations;
using Configurations.Helpers;

namespace BRADxTester;

public class ControllerConfTests
{
    IControllerConfig _controllerConfig;
    
    [SetUp]
    public void Setup()
    {
        _controllerConfig = new ControllerConfig();
    }

    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\BRADx\\bin\\Debug\\net8.0\\configs\\ics.reader.xml")]
    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\BRADx\\bin\\Debug\\net8.0\\configs\\ics.deck.xml")]
    public void LoadControllerConfigTest(string configXmlPath)
    {
        try
        {
            var controllerConfig = ControllerConfigXmlLoader.Load(configXmlPath);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\BRADx\\bin\\Debug\\net8.0\\configs\\ics.reader.xml")]
    [TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\BRADx\\bin\\Debug\\net8.0\\configs\\ics.deck.xml")]
    public void VerifyLoadedControllerConfigRootTest(string configXmlPath)
    {
        try
        {
            var controllerConfig = ControllerConfigXmlLoader.Load(configXmlPath);
            
            // verify a few things
            var controllerName = controllerConfig.Name;
            var controllerDescription = controllerConfig.Description;
            var controllerDisplayName = controllerConfig.DisplayName;
            
            var xmlDoc = XDocument.Load(configXmlPath);
            var root = xmlDoc.Root;
            if (root != null)
            {
                var name = root.Attribute("name")?.Value;
                Assert.That(name, Is.EqualTo(controllerName));
                var description = root.Attribute("description")?.Value;
                Assert.That(description, Is.EqualTo(controllerDescription));
                var displayName = root.Element("displayName")?.Value;
                if (displayName != null)
                {
                    Assert.That(displayName, Is.EqualTo(controllerDisplayName));
                }
            }
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
}