using Protocols;

namespace BRADxTester;

public class ProtocolTests
{
    IProtocol _protocol;
    
    [SetUp]
    public void Setup()
    {
        _protocol = new Protocol("Test Protocol", "Protocol used in this test");
    }

    [Test]
    public void ProtocolFunctionalityTest()
    {
        // Check if the creation date time is set
        Assert.IsNotNull(_protocol.GetCreationDateTime());
        
        // Add some steps and ensure things look right
        _protocol.AddStep(new Step
        {
            Description = "Home",
            Priority = PriorityEnum.Medium,
            User = "root"
        });
        var moveStep = new Step
        {
            Description = "Move to SampleTubeA",
            Priority = PriorityEnum.Medium,
            User = "root",
        };
        var wrongStep = new Step
        {
            Description = "Pickup tips in TipBox2",
            Priority = PriorityEnum.Medium,
            User = "root",
        };
        _protocol.AddStep(moveStep);
        _protocol.AddStep(wrongStep);
        Assert.True(_protocol.GetSteps().Count == 3);

        // Insert a step in the protocol and make sure it comes out correctly
        var missingStep = new Step
        {
            Description = "Pickup tips at TipBox1",
            Priority = PriorityEnum.Medium,
            User = "root"
        };
        _protocol.InsertStepAt(1, missingStep);
        Assert.True(_protocol.GetSteps().Count == 4);
        Assert.That(missingStep, Is.SameAs(_protocol.GetSteps()[1]));
        Assert.That(moveStep, Is.SameAs(_protocol.GetSteps()[2]));
        Assert.IsNotNull(_protocol.GetLastUpdateDateTime());
        
        // Test removing a step
        _protocol.RemoveStepAt(3);
        Assert.True(_protocol.GetSteps().Count == 3);
    }
}