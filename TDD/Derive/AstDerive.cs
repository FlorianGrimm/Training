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

public class DeriveVisitor : IVisitor
{
    public DeriveVisitor()
    {
    }
    public Ast Visit(Ast ast)
    {
        throw new NotImplementedException();
    }

    public Ast Visit(AstDerive ast)
    {
        return ast.Node.Visit(this);
    }

    public Ast Visit(AstConstant ast)
    {
        return new AstConstant(0);
    }

    public Ast Visit(AstVariable ast)
    {
        return new AstConstant(1);
    }

    public Ast Visit(AstAdd ast)
    {
        var left = new AstDerive(ast.Left).Visit(this);
        var right = new AstDerive(ast.Right).Visit(this);
        if (left is AstConstant constantLeft && right is AstConstant constantRight)
        {
            return new AstConstant(constantLeft.Value + constantRight.Value);
        }
        if (left is AstConstant constantLeft2 && constantLeft2.Value == 0)
        {
            return right;
        }
        if (right is AstConstant constantRight2 && constantRight2.Value == 0)
        {
            return left;
        }
        var result = new AstAdd(left, right);
        return result;
    }

    public Ast Visit(AstMultiply ast){
        // left * right
        return new AstAdd(
            new AstMultiply(
                new AstDerive(ast.Left).Visit(this),
                ast.Right),
            new AstMultiply(
                ast.Left,
                new AstDerive(ast.Right).Visit(this)));
    }

    public Ast Visit(AstPower ast)
    {
        // left ^ right 
        if (ast.Left is AstVariable variable && ast.Right is AstConstant constant)
        {
            return new AstMultiply(
                new AstConstant(constant.Value), 
                new AstPower(
                    variable,
                    new AstConstant(constant.Value - 1)));
        }
        throw new NotImplementedException();
    }
}