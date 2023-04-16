namespace Derive;

public class DeriveEngine
{
    public DeriveEngine()
    {        
    }

    public string Derive(string input)
    {
        var ast = this.Parse(input);
        return "1";
    }

    public Ast Parse(string input)
    {
        return new AstConstant(1);
    }
}