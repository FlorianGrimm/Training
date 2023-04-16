namespace Derive;

public class DeriveEngine
{
    public DeriveEngine()
    {
    }

    public string Derive(string input)
    {
        var ast = this.Parse(input);
        var astDerive =new AstDerive(ast);
        return astDerive.Derive().ToString();
    }

    public Ast Parse(string input)
    {
        var splittedInput = input.Trim().Split(' ');
        var list = new List<Ast>();
        for(int position=0; position<splittedInput.Length; position++)
        {
            var ast = this.Parse(splittedInput[position], list);
            list.Add(ast);
        }
        if (list.Count == 1)
        {
            return list[0];
        }
        else
        {
            throw new ArgumentException($"Invalid input {string.Join(" ; ", list.Select(ast=>ast.ToString()))} ");
        }
    }

    private Ast Parse(string input, List<Ast> list)
    {
        if (input == "x")
        {
            return new AstVariable("x");
        }

        if (input == "+")
        {
            return AstAdd.Parse(list);
        }

         if (input == "*")
        {
            return AstMultiply.Parse(list);
        }
        
        if (input == "^")
        {
            return AstPower.Parse(list);
        }

        if (Double.TryParse(input, out double value))
        {
            return new AstConstant(value);
        }

        throw new ArgumentException("Invalid input {input}");
    }
}