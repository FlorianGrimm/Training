namespace Derive;

public class SimplifyVisitor : IVisitor
{
    public Ast Visit(Ast ast)
    {
        throw new NotImplementedException();
    }

    public Ast Visit(AstDerive ast)
    {
        throw new NotImplementedException();
    }

    public Ast Visit(AstSimplify ast)
    {
        return ast.Node.Visit(this);
    }

    public Ast Visit(AstConstant ast)
    {
        return ast;
    }

    public Ast Visit(AstVariable ast)
    {
        return ast;
    }

    public Ast Visit(AstAdd ast)
    {
        if (ast.Left is AstConstant constantLeft2 && ast.Right is AstConstant constantRight2)
        {
            return new AstConstant(constantLeft2.Value + constantRight2.Value);
        }
        return ast;
    }

    public Ast Visit(AstMultiply ast)
    {
        var astLeft = ast.Left.Simplify();
        var astRight = ast.Right.Simplify();

        if (astLeft is AstConstant constantLeft && constantLeft.Value == 0)
        {
            return new AstConstant(0);
        }
        if (astRight is AstConstant constantRight && constantRight.Value == 0)
        {
            return new AstConstant(0);
        }
        if (astLeft is AstConstant constantLeft2 && constantLeft2.Value == 1)
        {
            return astRight;
        }
        if (astRight is AstConstant constantRight2 && constantRight2.Value == 1)
        {
            return astLeft;
        }
        if (astLeft is AstVariable variableLeft
            && astRight is AstVariable variableRight
            && variableLeft.Name == variableRight.Name)
        {
            return new AstPower(astLeft, new AstConstant(2));
        }
        if (astLeft is AstPower powerLeft
            && astRight is AstPower powerRight
            && powerLeft.Left is AstVariable variableLeft2
            && powerRight.Left is AstVariable variableRight2
            && variableLeft2.Name == variableRight2.Name)
        {
            return new AstPower(astLeft, new AstAdd(powerLeft.Right, powerRight.Right));
        }
        if (ReferenceEquals(astLeft, ast.Left) && ReferenceEquals(astRight, ast.Right))
        {
            return ast;
        }
        else
        {
            return new AstMultiply(astLeft, astRight);
        }
    }

    public Ast Visit(AstPower ast)
    {
        var astLeft = ast.Left.Simplify();
        var astRight = ast.Right.Simplify();
        {
            if (astRight is AstConstant constantRight && constantRight.Value == 0)
            {
                return new AstConstant(1);
            }
        }
        {
            if (astLeft is AstVariable variableLeft && astRight is AstConstant constantRight && constantRight.Value == 1)
            {
                return variableLeft;
            }
        }
        return ast;
    }
}
