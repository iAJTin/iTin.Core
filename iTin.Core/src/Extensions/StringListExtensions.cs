
using System.Collections.Generic;
using System.Text;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with lists of strings.
/// </summary>
public static class StringListExtensions
{
    /// <summary>
    /// Returns a new string with string items joined with a specified character separator.
    /// </summary>
    /// <param name="items">The list of string items to join into a single string.</param>
    /// <param name="separator">The character used to separate the items in the resulting string.</param>
    /// <returns>
    /// A string containing the items from the input list joined together with the specified separator.
    /// </returns>
    /// <remarks>
    /// This method concatenates each string item in the list with the specified separator.<br/>
    /// If the input list is empty, an empty string is returned.
    /// </remarks>
    public static string AsString(this List<string> items, char separator)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringListExtensions).Assembly.GetName().Name}, v{typeof(StringListExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringListExtensions).Namespace}, Class: {nameof(StringListExtensions)}");
        Logger.Instance.Debug(" Returns a new string with string items joined with specified char");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) AsString(this {typeof(List<string>)}, {typeof(char)})");
        Logger.Instance.Debug($"   > items: {items.Count}, [{items[0]} ...]");
        Logger.Instance.Debug($"   > separator: {separator}");

        var builder = new StringBuilder();

        foreach (var item in items)
        {
            builder.Append(item);
            builder.Append(separator);
        }

        var result = builder.ToString();
        if (string.IsNullOrEmpty(result))
        {
            result = result.Substring(0, result.Length - 1);
        }

        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }
}
