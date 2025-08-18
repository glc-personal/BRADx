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

    //[TestCase("C:\\Users\\gabri\\RiderProjects\\BRADx\\BRADx\\bin\\Debug\\net8.0\\configs\\ics.reader.xml")]
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
}