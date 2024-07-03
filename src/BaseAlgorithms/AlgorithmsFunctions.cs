namespace BaseAlgorithms;

public static class AlgorithmsFunctions
{
    public static HashSet<(double distance, double angle)> WallAndStick(double length, double step)
    {
        if (double.Round(step, 2) < double.Epsilon)
        {
            throw new ArgumentException("ERROR: Step should be greater than 0 and count of digits after point must be less than 2");
        }
        HashSet<(double distance, double angle)> answer = [];
        if (length <= 2.0)
        {
            throw new ArgumentException("ERROR: Length must be greater than 2");
        }
        if (!(0.0 < Math.Abs(step) && Math.Abs(step) < 1.0))
        {
            throw new ArgumentException("ERROR: Step should be between 0 and 1");
        }
        for (var currentDistance = 2.0; double.Round(currentDistance, 3) <= 3.0; currentDistance += step)
        {
            if (currentDistance >= length)
            {
                answer.Add((currentDistance, 0.0));
                return answer;
            }
            answer.Add((currentDistance, Math.Acos(currentDistance / length) * 180.0 / Math.PI));
        }

        return answer;
    }
}