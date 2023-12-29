
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace iTin.Core.Helpers;

/// <summary>
/// Provides utility methods for validating strings using regular expressions.<br/>
/// http://regexhero.net/tester/
/// </summary>
public static class RegularExpressionHelper
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string GuidPattern = @"^[A-Fa-f0-9]{32}$|^({|\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\))?$|^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string IntegerNumberPattern = @"^\d+$";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string IpPattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string PathPattern = @"^(.*/)?(?:$|(.+?)(?:(\.[^.]*$)|$))";

    #endregion

    #region public static methods

    /// <summary>
    /// Determines whether a string represents a numeric integer value.
    /// </summary>
    /// <param name="value">The string to be checked.</param>
    /// <returns>
    /// <see langword="true"/> if the string is a numeric integer value; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
    public static bool IsNumeric(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var format = new Regex(IntegerNumberPattern);
        var match = format.IsMatch(value);

        return match;
    }

    /// <summary>
    /// Determines whether a string represents a valid GUID (Globally Unique Identifier).
    /// </summary>
    /// <param name="value">The string to be checked.</param>
    /// <returns>
    /// <see langword="true"/> if the string is a valid GUID; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
    public static bool IsValidGuid(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var format = new Regex(GuidPattern);
        var match = format.IsMatch(value);

        return match;
    }

    /// <summary>
    /// Determines whether a string represents a valid IP address.
    /// </summary>
    /// <param name="value">The string to be checked.</param>
    /// <returns>
    /// <see langword="true"/> if the string is a valid IP address; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when the length of <paramref name="value"/> is greater than 15.</exception>
    public static bool IsValidIpAddress(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));
        SentinelHelper.IsTrue(value.Length > 15);

        var format = new Regex(IpPattern);
        var match = format.IsMatch(value);

        return match;
    }

    /// <summary>
    /// Determines whether a string represents a valid email address.
    /// </summary>
    /// <param name="value">The string to be checked.</param>
    /// <returns>
    /// <see langword="true"/> if the string is a valid email address; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
    public static bool IsValidEmailAddress(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var format = new Regex(EmailPattern);
        var match = format.IsMatch(value);

        return match;
    }

    /// <summary>
    /// Determines whether a string represents a valid file path.
    /// </summary>
    /// <param name="value">The string to be checked.</param>
    /// <returns>
    /// <see langword="true"/> if the string is a valid file path; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
    public static bool IsValidPath(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var format = new Regex(PathPattern);
        var match = format.IsMatch(value);

        return match;
    }

    #endregion
}
