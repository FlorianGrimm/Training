namespace Derive;

public class AstVariable : Ast
{
    public string Name {get; }

    public AstVariable(string name)
    {
        this.Name = name;
    }

    override public void AsString(StringBuilder sb)
    {
        sb.Append(this.Name);
    }

    override public Ast Visit(IVisitor visitor)
    {
        return visitor.Visit(this);
    }
}
