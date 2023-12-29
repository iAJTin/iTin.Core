
using System;
using System.Data;
using System.Text;

using iTin.Core.Helpers;

namespace iTin.Core;

/// <summary>
/// Contains extension methods for <see cref="DataTable"/> objects.
/// </summary>
public static class DataTableExtensions
{
    /// <summary>
    /// Converts a DataTable to an HTML table representation.
    /// </summary>
    /// <param name="input">The DataTable to be converted to an HTML table.</param>
    /// <returns>
    /// A string containing the HTML representation of the DataTable as a table.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the input DataTable is <see langword="null"/>.</exception>
    public static string ToHtmlTable(this DataTable input)
    {
        SentinelHelper.ArgumentNull(input, nameof(input));

        var html = new StringBuilder();
        html.Append("<table>");

        // add header row
        html.Append("<tr>");
        for (var i = 0; i < input.Columns.Count; i++)
        {
            html.AppendFormat("<td>{0}</td>", input.Columns[i].ColumnName);
        }

        html.Append("</tr>");

        // add rows
        for (var i = 0; i < input.Rows.Count; i++)
        {
            html.Append("<tr>");
            for (var j = 0; j < input.Columns.Count; j++)
            {
                html.AppendFormat("<td>{0}</td>", input.Rows[i][j]);
            }

            html.Append("</tr>");
        }

        html.Append("</table>");

        return html.ToString();
    }
}
