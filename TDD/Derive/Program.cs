namespace Derive;

public class Program{
    public static void Main(string[] args)
    {
        string input = string.Join(" ", args);
        var engine = new DeriveEngine();
        var result = engine.Derive(input);
        Console.WriteLine(result);
    }
}