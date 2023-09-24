using System.Text.RegularExpressions;

namespace WebShowcase;

public static partial class RegexHelper
{
    [GeneratedRegex("\\<title\\b[^>]*\\>\\s*(?<Title>[\\s\\S]*?)\\</title\\>")]
    public static partial Regex HtmlTitle();
}
