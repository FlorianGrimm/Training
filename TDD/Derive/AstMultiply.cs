namespace Derive;
public class AstMultiply : Ast
{
    public static AstMultiply Parse(List<Ast> list)
    {
        if (list.Count < 2)
        {
            throw new ArgumentException("Invalid input");
        }
        var right=list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        var left=list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return new AstMultiply(left, right);
    }

    public Ast Left { get; }
    public Ast Right { get; }

    public AstMultiply(Ast left, Ast right)
    {
        this.Left = left;
        this.Right = right;
    }

    override public void AsString(StringBuilder sb)
    {
        this.Left.AsString(sb);
        sb.Append(" ");
        this.Right.AsString(sb);
        sb.Append(" ");
        sb.Append("*");
    }

    override public Ast Visit(IVisitor visitor)
    {
        return visitor.Visit(this);
    }
}
