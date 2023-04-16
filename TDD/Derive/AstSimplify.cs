namespace Derive;

public class AstSimplify : Ast
{
    public AstSimplify(Ast node)
    {
        Node = node;
    }

    public Ast Node { get; }


    override public Ast Visit(IVisitor visitor)
    {
        return visitor.Visit(this);
    }
}
