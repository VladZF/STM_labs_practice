namespace BaseAlgorithms;

public static class Solution
{
    public static List<double> WallAndStick(double length, double distance, double step)
    {
        List<double> answer = [];
        if (step > 3)
        {
            throw new ArgumentException("Step is greater than 3");
        }
        if (distance >= length)
        {
            return [0];
        }
        for (var h = distance; h >= 0 && Math.Abs(h - distance) <= 3 && h < length; h += step)
        {
            answer.Add(Math.Acos(h / length) * 180 / Math.PI);
        }

        return answer;
    }
}