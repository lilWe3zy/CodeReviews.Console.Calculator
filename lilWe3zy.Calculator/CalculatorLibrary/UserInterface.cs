namespace CalculatorLibrary;

public static class Ui
{
    public static void DrawHeading()
    {
        Console.Clear();
        // Redundant verbatim string prefix for visual comfort
        Console.WriteLine(@"                        ");
        Console.WriteLine(@"__   __      __         ");
        Console.WriteLine(@"\ \ / /      \ \        ");
        Console.WriteLine(@" \ v / __  __ \ \__   __");
        Console.WriteLine(@"  > < /  \/ /  > \ \ / /");
        Console.WriteLine(@" / ^ ( ()  <  / ^ \ v / ");
        Console.WriteLine(@"/_/ \_\__/\_\/_/ \_> <_)");
        Console.WriteLine(@"                  / ^ \ ");
        Console.WriteLine(@"                 /_/ \_\");

        Console.WriteLine("The calculator of all time.\n");

        Console.WriteLine("a - addition");
        Console.WriteLine("s - subtraction");
        Console.WriteLine("m - multiplication");
        Console.WriteLine("d - division");

        Console.WriteLine("r - square root");
        Console.WriteLine("p - power of");
        Console.WriteLine("x - 10x");
        Console.WriteLine("t - trigonometry\n");

        Console.WriteLine("+++++++++++++++++++++++++\n");

        Console.WriteLine("h - View History");
        Console.WriteLine("q - Quit Program");
        Console.WriteLine("\n");
    }
}