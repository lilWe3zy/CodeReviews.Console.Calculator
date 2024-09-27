namespace CalculatorLibrary;

public class Helpers
{
    public static string? ReadInput(string? message)
    {
        if (message != null) Console.WriteLine(message);
        Console.Write("> ");
        var input = Console.ReadLine();

        return input;
    }
}