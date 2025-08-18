using System.Xml;

namespace Configurations.Exceptions;

public class ConfigParseException : Exception
{
    public int LineNumber { get; }
    public int LinePosition { get; }

    public ConfigParseException(string message, IXmlLineInfo lineInfo) : base(Format(message, lineInfo))
    {
        LineNumber = lineInfo.HasLineInfo() ? lineInfo.LineNumber : -1;
        LinePosition = lineInfo.HasLineInfo() ? lineInfo.LinePosition : -1;
    }

    private static string Format(string message, IXmlLineInfo lineInfo)
    {
        if (lineInfo.HasLineInfo())
            return $"{message} (line {lineInfo.LineNumber}, pos {lineInfo.LinePosition})";
        return message;
    }
}