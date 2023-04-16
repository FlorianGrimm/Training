namespace Derive;

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

    public Ast Visit(AstSimplify ast)
    {
        return ast.Node.Visit(new SimplifyVisitor());
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
        return new AstAdd(left, right).Simplify();
    }

    public Ast Visit(AstMultiply ast){
        // left * right
        return new AstAdd(
            new AstMultiply(
                new AstDerive(ast.Left).Visit(this),
                ast.Right),
            new AstMultiply(
                ast.Left,
                new AstDerive(ast.Right).Visit(this))).Simplify();
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
                    new AstConstant(constant.Value - 1)).Simplify()
                    );
        }
        throw new NotImplementedException();
    }
}