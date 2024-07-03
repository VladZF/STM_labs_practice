namespace BaseAlgorithms;

public static class AlgorithmsFunctions
{
    public static (bool isExists, bool isRightAngled) IsTriangleExists(double firstAngle, double secondAngle)
    {
        if (firstAngle <= 0.0 || firstAngle > 180.0 || secondAngle <= 0.0 || secondAngle > 180.0 || firstAngle + secondAngle >= 180.0)
            return (false, false);

        var thirdAngle = 180.0 - firstAngle - secondAngle;
        if (Math.Abs(firstAngle - 90) < double.Epsilon || Math.Abs(secondAngle - 90) < double.Epsilon || Math.Abs(thirdAngle - 90) < double.Epsilon)
            return (true, true);

        return (true, false);
    }
}