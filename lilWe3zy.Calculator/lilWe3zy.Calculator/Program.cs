using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace lilWe3zy.Calculator;

internal static partial class Program
{
    private static void Main()
    {
        var calculator = new CalculatorLibrary.Calculator();
        bool endApp = false;

        Ui.DrawHeading();

        while (!endApp)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            double firstOperand;
            while (!double.TryParse(input, out firstOperand))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                input = Console.ReadLine();
            }

            Console.Write("Type another number, and then press Enter: ");
            input = Console.ReadLine();

            double secondOperand;
            while (!double.TryParse(input, out secondOperand))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            input = Console.ReadLine();

            if (input == null || !InputCheck().IsMatch(input))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    double result = calculator.DoOperation(firstOperand, secondOperand, input);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }

            Console.WriteLine("------------------------\n");
            Console.Write("Press 'q' and Enter to close the app, or press Enter to continue: ");
            if (Console.ReadLine() == "q")
            {
                endApp = true;
            }

            Console.WriteLine("\n");
        }

        calculator.Finish();
    }

    [GeneratedRegex("[a|s|m|d]")]
    private static partial Regex InputCheck();
}