namespace Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        return char.ToLowerInvariant(str[0]) + str.Substring(1);
    }

    public static string ToTitleCase(this string str)
    {
        return str.Substring(0, 1).ToUpper() + str.Substring(1);
    }
}