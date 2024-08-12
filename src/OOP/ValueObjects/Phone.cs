using System.Text.RegularExpressions;
using ValueOf;

namespace OOP;

public partial class Phone : ValueOf<string, Phone>
{
    protected override void Validate()
    {
        if (!PhonePattern().IsMatch(Value))
        {
            throw new FormatException("Phone number has incorrect format");
        }
    }

    [GeneratedRegex(@"^(\+7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$")]
    private static partial Regex PhonePattern();
}