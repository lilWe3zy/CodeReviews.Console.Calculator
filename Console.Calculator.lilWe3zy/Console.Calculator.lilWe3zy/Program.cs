/*
 * REQUIREMENTS
 *
 * [x] Complete the following tutorial: Create a Calculator App (Microsoft Docs)
 *
 * CHALLENGES
 *
 * [x] Create a functionality that will count the amount of times the calculator was used.
 * [] Store a list with the latest calculations. And give the users the ability to delete that list.
 * [] Allow the users to use the results in the list above to perform new calculations.
 * [x] Add extra calculations: Square Root, Taking the Power, 10x, Trigonometry functions.
 */

using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace Console.Calculator.lilWe3zy;

internal static partial class Program
{
    private static void Main(string[] args)
    {
        var calculator = new CalculatorLibrary.Calculator();
        var calculatorCount = 0;

        System.Console.WriteLine("""
                                  _____       _            _       _             
                                 /  __ \     | |          | |     | |            
                                 | /  \/ __ _| | ___ _   _| | __ _| |_ ___  _ __ 
                                 | |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|
                                 | \__/\ (_| | | (__| |_| | | (_| | || (_) | |   
                                  \____/\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   
                                  
                                 """);

        while (true)
        {
            System.Console.Clear();
            DisplayMenu(calculatorCount);
            var selection = Helpers.ReadInput("Please select an option.");

            while (selection == null || !InputRegex().IsMatch(selection))
                selection = Helpers.ReadInput("Please enter a valid option.");

            if (selection == "n")
            {
                calculator.Finish();
                return;
            }

            try
            {
                var result = calculator.DoOperation(selection);
                if (double.IsNaN(result))
                    System.Console.WriteLine("This operation will result in a mathematical error.\n");
                else System.Console.WriteLine("Your result: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " +
                                         e.Message);
            }

            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey();

            calculatorCount++;
        }
    }


    private static void DisplayMenu(int calculatorCount)
    {
        System.Console.WriteLine("Please choose an option:");
        System.Console.WriteLine("");
        System.Console.WriteLine(" a -\tAddition (x + y)");
        System.Console.WriteLine(" s -\tSubtraction (x - y)");
        System.Console.WriteLine(" m -\tMultiplication (x * y)");
        System.Console.WriteLine(" d -\tDivision (x / y)");
        System.Console.WriteLine(" sqrt -\tSquare Root (x)");
        System.Console.WriteLine(" pow -\tPower Of (x ^ y)");
        System.Console.WriteLine(" sin -\tsin(x)");
        System.Console.WriteLine(" cos -\tcos(x)");
        System.Console.WriteLine(" tan -\ttan(x)");
        System.Console.WriteLine("");
        System.Console.WriteLine(" l -\tList previous calculations this session");
        System.Console.WriteLine(" ld -\tDelete log list");
        System.Console.WriteLine(" n -\tExit");
        System.Console.WriteLine("");
        System.Console.WriteLine($"Calculations performed this session: {calculatorCount}\n");
    }

    [GeneratedRegex("[a|s|m|d|sqrt|pow|sin|cos|tan|l|ld|n]")]
    private static partial Regex InputRegex();
}