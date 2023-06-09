namespace Derive;

public class AstDerive : Ast
{
    public AstDerive(Ast node)
    {
        Node = node;
    }

    public Ast Node { get; }


    override public Ast Visit(IVisitor visitor)
    {
        return visitor.Visit(this);
    }
}
