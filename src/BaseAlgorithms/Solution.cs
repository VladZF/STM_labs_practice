using System.Text;

namespace BaseAlgorithms;

public static class Solution
{
    public static string CompressBinarySequence(string sequence)
    {
        if (sequence.Length == 0)
            return string.Empty;
        var answer = new StringBuilder();
        var counter = 0;
        if (sequence[^1] == '0')
            throw new ArgumentException("Impossible to compress sequence");
        foreach (var c in sequence)
        {
            if (c != '0' && c != '1')
            {
                throw new FormatException("Sequence is not binary");
            }
            if (c == '1')
            {
                answer.Append((char)('a' + counter));
                counter = -1;
            }

            counter++;
            if (counter > 26)
                throw new ArgumentException("Impossible to compress sequence");
        }
        return answer.ToString();
    }
}