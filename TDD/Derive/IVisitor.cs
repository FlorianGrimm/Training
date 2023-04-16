namespace Derive;

public interface IVisitor
{
    Ast Visit(Ast ast);
    Ast Visit(AstDerive ast);
    Ast Visit(AstSimplify ast);
    Ast Visit(AstConstant ast);
    Ast Visit(AstVariable ast);
    Ast Visit(AstAdd ast);
    Ast Visit(AstMultiply ast);
    Ast Visit(AstPower ast);
}
