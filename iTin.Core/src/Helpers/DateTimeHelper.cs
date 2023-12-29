
using System;

namespace iTin.Core.Helpers;

/// <summary>
/// A helper class providing methods for working with <see cref="DateTime"/>.
/// </summary>
public static class DateTimeHelper
{
    /// <summary>
    /// Converts a Unix timestamp represented in milliseconds to a <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="milliseconds">The Unix timestamp in milliseconds to be converted.</param>
    /// <returns>A <see cref="DateTime"/> object representing the converted Unix timestamp in the local time zone.</returns>
    /// <remarks>
    /// The Unix timestamp is the number of milliseconds that have elapsed since January 1, 1970 (midnight UTC/GMT), not counting leap seconds.<br/>
    /// This method assumes that the input timestamp is in milliseconds.
    /// </remarks>
    public static DateTime FromUnixTimeStamp(double milliseconds)
    {
        var datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        datetime = datetime.AddMilliseconds(milliseconds).ToLocalTime();

        return datetime;
    }
}
