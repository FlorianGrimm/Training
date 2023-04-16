namespace Derive.Tests;

public class DeriveEngineTests
{
    [Fact]
    public void DeriveEngine_Hack()
    {
        var engine = new DeriveEngine();        
        //var result = engine.Parse("x 2 ^").Derive().ToString();
        //Assert.Equal("2 x 1 ^ *", result);
        var result = engine.Parse("x 2 ^").Derive().ToString();
        Assert.Equal("2 x *", result);
    }

    [Theory]
    [InlineData("1", "0")]
    [InlineData("x 1 +", "1")]
    //[InlineData("x 2 ^", "2 x *")]
    public void DeriveEngine_Theory(string input, string expected)
    {
        var engine = new DeriveEngine();
        var result = engine.Derive(input);
        Assert.Equal(expected, result);
    }
}