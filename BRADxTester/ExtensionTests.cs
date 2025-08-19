using Extensions;

namespace BRADxTester;

public class ExtensionTests
{
    [TestCase("NotCamelCase", "notCamelCase")]
    //[TestCase("NotcamelCase", "notCamelCase")]
    //[TestCase("Notcamelcase", "notCamelCase")]
    //[TestCase("notcamelCase", "notCamelCase")]
    //[TestCase("NotCAmelCase", "notCamelCase")]
    public void StringExtensionCamelCaseTest(string input, string expected)
    {
        Assert.That(input.ToCamelCase(), Is.EqualTo(expected));
    }
}