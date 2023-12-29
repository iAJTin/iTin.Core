
using System.Data;
using System.Xml;

namespace iTin.Core.Helpers;

/// <summary>
/// A utility class for XML-related operations.
/// </summary>
public static class XmlHelper
{
    /// <summary>
    /// Converts an XML string to a <see cref="DataSet"/>.
    /// </summary>
    /// <param name="xml">The XML string to be converted.</param>
    /// <returns>
    /// A <see cref="DataSet"/> containing the data from the XML string.
    /// </returns>
    /// <exception cref="XmlException">Thrown when an error occurs while loading or parsing the XML string.</exception>
    /// <remarks>
    /// This method attempts to parse the provided XML string and populate a <see cref="DataSet"/> with the data.
    /// If the XML string is invalid or cannot be parsed, an <see cref="XmlException"/> is thrown.
    /// </remarks>
    public static DataSet ToDataSet(string xml)
    {
        var result = new DataSet();

        try
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            result.ReadXml(new XmlNodeReader(document));

            return result;
        }
        catch
        {
            throw;
        }
    }
}
