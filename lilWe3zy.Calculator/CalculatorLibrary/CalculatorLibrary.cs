using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
    private readonly JsonWriter _writer;

    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calc-log.json");
        logFile.AutoFlush = true;

        _writer = new JsonTextWriter(logFile);
        _writer.Formatting = Formatting.Indented;
        _writer.WriteStartObject();
        _writer.WritePropertyName("Operations");
        _writer.WriteStartArray();
    }

    public double DoOperation(double firstOperand, double secondOperand, string operation)
    {
        double result = double.NaN;

        _writer.WriteStartObject();
        _writer.WritePropertyName("Operand1");
        _writer.WriteValue(firstOperand);
        _writer.WritePropertyName("Operand2");
        _writer.WriteValue(secondOperand);
        _writer.WritePropertyName("Operation");

        switch (operation)
        {
            case "a":
                result = firstOperand + secondOperand;
                _writer.WriteValue("Add");
                break;
            case "s":
                result = firstOperand - secondOperand;
                _writer.WriteValue("Subtract");
                break;
            case "m":
                result = firstOperand * secondOperand;
                _writer.WriteValue("Multiply");
                break;
            case "d":
                // Catch zero division
                if (secondOperand != 0)
                {
                    result = firstOperand / secondOperand;
                }

                _writer.WriteValue("Divide");
                break;
            case "r":
                _writer.WriteValue("Square root");
                break;
            default:
                Console.WriteLine("I could not understand that option, please try again.");
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