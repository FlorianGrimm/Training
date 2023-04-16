namespace Derive.Tests;

public class SimplifyTests
{
    [Fact]
    public void Simplify_Hack(){
        var result = new DeriveEngine().Parse("x x *").Simplify();
        Assert.Equal("x 2 ^", result.ToString());
    }

    [Theory]
    [InlineData("x x *", "x 2 ^")]
    [InlineData("x", "x")]
    [InlineData("42", "42")]
    [InlineData("42 0 +", "42")]
    //[InlineData("x 2 ^ x 2 ^ *", "x 4 ^")]
    [InlineData("2 x 1 ^ *", "2 x *")]
    public void Simplify_Theory(string input, string expected)
    {
        var result = new DeriveEngine().Parse(input).Simplify();
        Assert.Equal(expected, result.ToString());
    }
}