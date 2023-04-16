namespace Derive;
public class AstPlus : Ast
{
    public static AstPlus Parse(List<Ast> list)
    {
        if (list.Count < 2)
        {
            throw new ArgumentException("Invalid input");
        }
        var right=list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        var left=list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return new AstPlus(left, right);
    }

    public Ast Left { get; }
    public Ast Right { get; }


    public AstPlus(Ast left, Ast right)
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
        sb.Append("+");
    }
}
