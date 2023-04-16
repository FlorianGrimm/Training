namespace Derive;

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

    override public Ast Visit(IVisitor visitor)
    {
        return visitor.Visit(this);
    }
}