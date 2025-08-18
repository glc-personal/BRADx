using System.Xml;

namespace IO.Converters;

public class XmlFileToXmlDocumentConverter : IConverter<FileStream, XmlDocument>
{
    public XmlDocument Convert(FileStream input)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(input);
        return doc;
    }
}