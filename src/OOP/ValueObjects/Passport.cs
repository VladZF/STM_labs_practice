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
    
    [GeneratedRegex(@"^(\+7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$")]
    private static partial Regex PassportPattern();
}