using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
    private readonly JsonWriter _writer;

    public Calculator()
    {
        var logFile = File.CreateText("log.json");
        logFile.AutoFlush = true;
        _writer = new JsonTextWriter(logFile);
        _writer.Formatting = Formatting.Indented;
        _writer.WriteStartObject();
        _writer.WritePropertyName("Operations");
        _writer.WriteStartArray();
    }

    private static List<double> ParseList(List<string> list)
    {
        return list.Select(element => double.TryParse(element, out var number) ? number : double.NaN).ToList();
    }

    public double DoOperation(string operation)
    {
        var operands = new List<string>();
        var result = double.NaN;

        // Determine the operand message
        var selection = operation switch
        {
            "sqrt" or "sin" or "cos" or "tan" => Helpers.ReadInput(
                "Please enter operand (additional operands will be ignored"),
            "pow" => Helpers.ReadInput(
                "Please enter operands (values after the second will be ignored)"),
            _ => Helpers.ReadInput("Please enter operands (delimited by space)")
        };

        while (selection == null)
            selection = Helpers.ReadInput("Please enter valid operand(s)");

        operands.AddRange(selection.Split(' '));

        // Parse into new list of double, if parse unsuccessful, element marked as NAN
        var numbers = ParseList(operands);

        _writer.WriteStartObject();

        for (var i = 0; i < numbers.Count; i++)
        {
            _writer.WritePropertyName($"Operand{i + 1}");
            _writer.WriteValue(numbers[i]);
        }

        _writer.WritePropertyName("Operation");

        // Determine and do operation
        switch (operation)
        {
            case "a":
                result = numbers.Sum();
                _writer.WriteValue("Addition");
                break;
            case "s":
                result = numbers.Aggregate((current, number) => current - number);
                _writer.WriteValue("Subtraction");
                break;
            case "m":
                result = numbers.Aggregate((current, number) => current * number);
                _writer.WriteValue("Multiplication");
                break;
            case "d":
                // Zero values will be ignored
                result = numbers.Where(number => number != 0).Aggregate((current, number) => current / number);
                _writer.WriteValue("Division");
                break;
            case "sqrt":
                result = Math.Sqrt(numbers[0]);
                _writer.WriteValue("Square Root");
                break;
            case "pow":
                result = Math.Pow(numbers[0], numbers[1]);
                _writer.WriteValue("Power Of");
                break;
            case "sin":
                result = Math.Sin(numbers[0]);
                _writer.WriteValue("Sine");
                break;
            case "cos":
                result = Math.Cos(numbers[0]);
                _writer.WriteValue("Cosine");
                break;
            case "tan":
                result = Math.Tan(numbers[0]);
                _writer.WriteValue("Tangent");
                break;
        }

        _writer.WritePropertyName("Result");
        _writer.WriteValue(result);
        _writer.WriteEndObject();

        return result;
    }

    public void Finish()
    {
        _writer.WriteEndArray();
        _writer.WriteEndObject();
        _writer.Close();
    }
}