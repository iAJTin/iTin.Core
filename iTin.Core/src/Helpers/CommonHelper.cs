
using System.Globalization;

using iTin.Logging;

namespace iTin.Core.Helpers;

/// <summary>
/// A helper class providing common utility methods.
/// </summary>
public static class CommonHelper
{
    /// <summary>
    /// Determines whether the specified value is numeric using the specified <see cref="NumberStyles"/>.
    /// </summary>
    /// <param name="target">The string to be checked for numeric representation.</param>
    /// <param name="numberStyle">A bitwise combination of enumeration values that specifies the style elements that can be present in the target string.</param>
    /// <returns>
    /// <see langword="true"/> if the specified value is numeric; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsNumeric(string target, NumberStyles numberStyle)
    {
        Logger.Instance.Debug("External Call");
        Logger.Instance.Info("  Determines whether the specified value is numeric");
        Logger.Instance.Info("  > Library: iTin.Core");
        Logger.Instance.Info("  > Class: CommonHelper");
        Logger.Instance.Info("  > Method: IsNumeric(string, NumberStyles)");
        Logger.Instance.Info("  > Output: bool");

        return double.TryParse(target, numberStyle, CultureInfo.CurrentCulture, out _);
    }
}
