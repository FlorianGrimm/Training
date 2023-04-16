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

    
    public Ast Derive()
    {
        return this.Visit(new DeriveVisitor());
    }

    
    public Ast Simplify()
    {
        return this.Visit(new SimplifyVisitor());
    }

    public virtual Ast Visit(IVisitor visitor)
    {
        return visitor.Visit(this);
    }
}
