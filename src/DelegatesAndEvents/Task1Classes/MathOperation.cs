namespace DelegatesAndEvents;

public class MathOperation
{ 
    public delegate double Operation(double first, double second);
    
    public static Operation GiveOperation(double first, double second, string operation)
    {
        return operation switch
        {
            "+" => (firstNumber, secondNumber) => firstNumber + secondNumber,
            "-" => (firstNumber, secondNumber) => firstNumber - secondNumber,
            "*" => (firstNumber, secondNumber) => firstNumber * secondNumber,
            "/" => (firstNumber, secondNumber) =>
            {
                if (secondNumber == 0)
                {
                    throw new DivideByZeroException("You are trying divide by zero");
                }
                return firstNumber / secondNumber;
            },
            _ => throw new ArgumentOutOfRangeException(null, $"'{operation}' operation does not support")
        };
    }
}