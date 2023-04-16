namespace Derive.Tests;

public class DeriveEngineParseTests
{
    [Fact]
    public void DeriveEngineParse_1()
    {
        var engine = new DeriveEngine();
        var result = engine.Parse("1");
        Assert.Equal("1", result.ToString());
    }

    // [Fact]
    // public void DeriveEngineParse_xplus1()
    // {
    //     var engine = new DeriveEngine();
    //     var result = engine.Parse("x 1 +");
    //     Assert.Equal("1", result);
    // }
}