namespace DelegatesAndEvents;

public class Calculator
{
    public static double GetResult(double firstNumber, double secondNumber, string mathOperator)
    {
        var operation = MathOperation.GiveOperation(firstNumber, secondNumber, mathOperator);
        return operation(firstNumber, secondNumber);
    }
}