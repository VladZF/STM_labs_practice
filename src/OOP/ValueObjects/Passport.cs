using System.Text.RegularExpressions;
using ValueOf;

namespace OOP;

public partial class Passport : ValueOf<string, Passport>
{
    protected override void Validate()
    {
        if (!PassportPattern().IsMatch(Value))
        {
            throw new FormatException("Passport number has incorrect format");
        }
    }
    
    [GeneratedRegex("^([0-9]{4}\\s{1}[0-9]{6})?$")]
    private static partial Regex PassportPattern();
}