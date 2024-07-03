namespace BaseAlgorithms;

public static class Solution
{
    public static (bool, bool) IsTriangleExists(double a, double b)
    {
        if (a > 180.0 || b > 180.0 || a + b >= 180.0)
            return (false, false);

        var c = 180.0 - a - b;
        if (Math.Abs(a - 90) < double.Epsilon || Math.Abs(b - 90) < double.Epsilon || Math.Abs(c - 90) < double.Epsilon)
            return (true, true);

        return (true, false);
    }
}