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
