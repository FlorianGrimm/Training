namespace Derive;

public class Ast
{
    public Ast()
    {
    }

    override public string ToString()
    {
        var sb = new StringBuilder();
        this.AsString(sb);
        return sb.ToString();
    }

    public virtual void AsString(StringBuilder sb)
    {
        sb.Append("TODO");
    }
}

public class AstConstant : Ast
{
    public AstConstant(double value)
    {
        this.Value = value;
    }

    public double Value { get; }

    override public void AsString(StringBuilder sb)
    {
        sb.Append(this.Value.ToString());
    }
}