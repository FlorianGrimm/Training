namespace Derive.Tests;

public class DeriveEngineTests
{
    [Fact]
    public void DeriveEngine_xplus1()
    {
        var engine = new DeriveEngine();
        var result = engine.Derive("x 1 +");
        Assert.Equal("1", result);
    }

    [Theory]
    //[InlineData("1", "0")]
    [InlineData("x 1 +", "1")]
    public void DeriveEngine_Theory(string input, string expected)
    {
        var engine = new DeriveEngine();
        var result = engine.Derive(input);
        Assert.Equal(expected, result);
    }
}