using System.Text;

namespace BaseAlgorithms;

public static class AlgorithmsFunctions
{
    public static string CompressBinarySequence(string sequence)
    {
        if (sequence.Length == 0)
            return string.Empty;
        var answer = new StringBuilder();
        var counter = 0;
        if (sequence[^1] == '0')
            throw new ArgumentException("Impossible to compress sequence");
        foreach (var currentChar in sequence)
        {
            if (currentChar != '0' && currentChar != '1')
            {
                throw new FormatException("Sequence is not binary");
            }
            if (currentChar == '1')
            {
                answer.Append((char)('a' + counter));
                counter = 0;
                continue;
            }

            counter++;
            if (counter > 26)
                throw new ArgumentException("Impossible to compress sequence");
        }
        return answer.ToString();
    }
  
    public static (bool isExists, bool isRightAngled) IsTriangleExists(double firstAngle, double secondAngle)
    {
        if (firstAngle <= 0.0 || firstAngle > 180.0 || secondAngle <= 0.0 || secondAngle > 180.0 || firstAngle + secondAngle >= 180.0)
            return (false, false);

        var thirdAngle = 180.0 - firstAngle - secondAngle;
        if (Math.Abs(firstAngle - 90) < double.Epsilon || Math.Abs(secondAngle - 90) < double.Epsilon || Math.Abs(thirdAngle - 90) < double.Epsilon)
            return (true, true);

        return (true, false);
    }

    public static (HashSet<string> everywhere, HashSet<string> nowhere) ToysInKinderGardens(HashSet<string> toys,
        List<HashSet<string>> gardens)
    {
        HashSet<string> everywhere = [];
        HashSet<string> nowhere = [];
        foreach (var toy in toys)
        {
            var counter = gardens.Count(garden => garden.Contains(toy));
            if (counter == gardens.Count)
            {
                everywhere.Add(toy);
            } 
            else if (counter == 0)
            {
                nowhere.Add(toy);
            }
        }
        return (everywhere, nowhere);
    }
}