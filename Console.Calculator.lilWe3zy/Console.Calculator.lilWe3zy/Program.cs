﻿/*
 * REQUIREMENTS
 *
 * Complete the following tutorial: Create a Calculator App (Microsoft Docs)
 *
 * CHALLENGES
 *
 * - Create a functionality that will count the amount of times the calculator was used.
 * - Store a list with the latest calculations. And give the users the ability to delete that list.
 * - Allow the users to use the results in the list above to perform new calculations.
 * - Add extra calculations: Square Root, Taking the Power, 10x, Trigonometry functions.
 */

using System.Text.RegularExpressions;

namespace Console.Calculator.lilWe3zy;

internal static class Program
{
    private static void Main(string[] args)
    {
        var endApp = false;
        // Display title as the C# console calculator app.
        System.Console.WriteLine("Console Calculator in C#\r");
        System.Console.WriteLine("------------------------\n");

        var calculator = new CalculatorLibrary.Calculator();

        while (!endApp)
        {
            // Declare variables and set to empty.
            // Use Nullable types (with ?) to match type of System.Console.ReadLine
            var numInput1 = "";
            var numInput2 = "";
            double result = 0;

            // Ask the user to type the first number.
            System.Console.Write("Type a number, and then press Enter: ");
            numInput1 = System.Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                System.Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = System.Console.ReadLine();
            }

            // Ask the user to type the second number.
            System.Console.Write("Type another number, and then press Enter: ");
            numInput2 = System.Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                System.Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = System.Console.ReadLine();
            }

            // Ask the user to choose an operator.
            System.Console.WriteLine("Choose an operator from the following list:");
            System.Console.WriteLine("\ta - Add");
            System.Console.WriteLine("\ts - Subtract");
            System.Console.WriteLine("\tm - Multiply");
            System.Console.WriteLine("\td - Divide");
            System.Console.Write("Your option? ");

            var op = System.Console.ReadLine();

            // Validate input is not null, and matches the pattern
            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                System.Console.WriteLine("Error: Unrecognized input.");
            else
                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                        System.Console.WriteLine("This operation will result in a mathematical error.\n");
                    else System.Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " +
                                             e.Message);
                }

            System.Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            System.Console.Write(
                "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (System.Console.ReadLine() == "n") endApp = true;

            System.Console.WriteLine("\n"); // Friendly linespacing.

            calculator.Finish();
            return;
        }
    }
}