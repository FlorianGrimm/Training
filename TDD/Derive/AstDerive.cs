namespace Derive;
public class AstDerive
{
    public AstDerive(Ast node)
    {
        Node = node;
    }

    public Ast Node { get; }

    public Ast Derive()
    {
        return this.Node;
    }
}
