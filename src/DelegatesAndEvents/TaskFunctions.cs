namespace DelegatesAndEvents;

public static class TaskFunctions
{
    private delegate double Operation(double firstNumber, double secondNumber);
    public static double Calculator(double firstNumber, double secondNumber, MathOperation operatator)
    {
        Operation? operation = operatator switch
        {
            MathOperation.Sum => (first, second) => first + second,
            MathOperation.Subtract => (first, second) => first - second,
            MathOperation.Multiply => (first, second) => first * second,
            MathOperation.Divide => (first, second) =>
            {
                if (second == 0)
                {
                    throw new DivideByZeroException("You trying to divide by zero");
                }
                return first / second;
            },
            _ => null
        };
        if (operation == null)
        {
            throw new ArgumentException($"Calculator does not support this operation");
        }
        return operation(firstNumber, secondNumber);
    }
}