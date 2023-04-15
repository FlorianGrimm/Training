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
}