namespace Derive.Tests;

public class DeriveEngineParseTests
{
    [Theory]
    [InlineData("1", "1")]
    [InlineData("x", "x")]
    [InlineData("x 1 +", "x 1 +")]
    [InlineData("x 2 ^", "x 2 ^")]
    public void DeriveEngineParse(string input, string expected)
    {
        var engine = new DeriveEngine();
        var result = engine.Parse(input);
        Assert.Equal(expected, result.ToString());
    }
    
    [Fact]
    public void DeriveEngineParse_xpower2()
    {
        var engine = new DeriveEngine();
        var result = engine.Parse("x 2 ^");
        Assert.Equal("x 2 ^", result.ToString());
    }
}