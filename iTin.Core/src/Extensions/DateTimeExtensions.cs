
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
    
    using System.Linq;

#endif

using System;
using System.Globalization;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for <see cref="DateTime"/>.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> object to <b>yyyy-MM-dd HH:mm:ss.fff</b> string format.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the expected format.
    /// </returns>
    public static string ToLongDataBaseFormatAsDateTime(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts a DateTime object to 'yyyy-MM-dd HH:mm:ss.fff' string format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToLongDataBaseFormatAsDateTime(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = target.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object to <b>yyyy-MM-dd HH:mm:ss</b> string format.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the expected format.
    /// </returns>
    public static string ToShortDataBaseFormatAsDateTime(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts a DateTime object to 'yyyy-MM-dd HH:mm:ss' string format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToShortDataBaseFormatAsDateTime(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = target.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object to <b>yyyyMMddHHmmss.fff</b> string format.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the expected format.
    /// </returns>
    public static string ToLongDataBaseFormatAsString(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts a DateTime object to 'yyyyMMddHHmmss.fff' string format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToLongDataBaseFormatAsDateTime(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = target.ToString("yyyyMMddHHmmss.fff", CultureInfo.InvariantCulture);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object into <b>yyyyMMddHHmmss</b> string.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the expected format.
    /// </returns>
    public static string ToShortDataBaseFormatAsString(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts a DateTime object to 'yyyyMMddHHmmss' string format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToShortDataBaseFormatAsString(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = target.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object into <b>dd/MM/yyyy</b> string.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the expected format.
    /// </returns>
    public static string ToShortUiFormatAsString(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts a DateTime object to 'dd/MM/yyyy' string format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToShortUiFormatAsString(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = target.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object into <b>dd/MM/yyyy HH'h'</b> string.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the expected format.
    /// </returns>
    public static string ToShortUiFormatWithShortTimeAsString(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts a DateTime object to 'dd/MM/yyyy HH'h'' string format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToShortUiFormatWithShortTimeAsString(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = $"{target.Day.ToString().PadLeft(2, '0')}/{target.Month.ToString().PadLeft(2, '0')}/{target.Year.ToString().PadLeft(2, '0')} {target.Hour.ToString().PadLeft(2, '0')}h";
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object into <b>dd/MM/yyyy HH:mm:ss</b> string.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the expected format.
    /// </returns>
    public static string ToLongUiFormatAsString(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts a DateTime object to 'dd/MM/yyyy HH:mm:ss' string format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToLongUiFormatAsString(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = target.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts time of the <see cref="DateTime"/> object with format <b>HH:mm:ss</b>.
    /// </summary>
    /// <param name="target">Target datetime.</param>
    /// <returns>
    /// A <see cref="string"/> that contains time of target datetime.
    /// </returns>
    public static string ToTimeSpanUiAsString(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug(" Converts time of the DateTime object with format 'HH:mm:ss'");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToTimeSpanUiAsString(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        string result = target.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Returns only the date part of the specified <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="target">The <see cref="DateTime"/> value to extract the date part from.</param>
    /// <returns>
    /// A string representing only the date part of the specified <see cref="DateTime"/> value.
    /// </returns>
    public static string DatePartOnly(this DateTime target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(DateTimeExtensions).Assembly.GetName().Name}, v{typeof(DateTimeExtensions).Assembly.GetName().Version}, Namespace: {typeof(DateTimeExtensions).Namespace}, Class: {nameof(DateTimeExtensions)}");
        Logger.Instance.Debug($" Returns only date part of target {typeof(DateTime)}");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) DatePartOnly(this {typeof(DateTime)})");
        Logger.Instance.Debug($"   > target: {target.ToString(CultureInfo.CurrentCulture)}");

        var dateAndTime = target.Split();
        var datePart = dateAndTime[0];

        Logger.Instance.Debug($"  > Output: {datePart}");

        return datePart;
    }

    /// <summary>
    /// Creates a new a <see cref="DateTime"/> object with the first day of the month.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> to get the year and month.</param>
    /// <returns>
    /// A <see cref="DateTime"/> representing the first day of the month.
    /// </returns>
    public static DateTime FirstDayInMonth(this DateTime value)
        => new(value.Year, value.Month, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Creates a new a <see cref="DateTime"/> object with the last day of the month.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> to get the year and month.</param>
    /// <returns>
    /// A <see cref="DateTime"/> representing the last day of the month.
    /// </returns>
    public static DateTime LastDayInMonth(this DateTime value)
        => value.FirstDayInMonth().AddMonths(1).AddDays(-1);

    /// <summary>
    /// Splits the specified <see cref="DateTime"/> value into date and time parts.
    /// </summary>
    /// <param name="target">The <see cref="DateTime"/> value to split.</param>
    /// <returns>
    /// An array containing the date and time parts of the specified <see cref="DateTime"/> value.<br/>
    /// The date and time parts are represented as strings.
    /// </returns>
    public static string[] Split(this DateTime target)
    {
        var databaseFullDate = target.ToString(CultureInfo.CurrentCulture);

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

            return databaseFullDate.SplitString([' ']).AsEnumerable().ToArray();
#else
        return databaseFullDate.Split([' '], StringSplitOptions.RemoveEmptyEntries);
#endif
    }

    /// <summary>
    /// Extracts the time part (hour, minute, and second) from the specified <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="target">The <see cref="DateTime"/> value from which to extract the time part.</param>
    /// <returns>
    /// A string representation of the time part (hour:minute:second) of the specified <see cref="DateTime"/> value.<br/>
    /// If the original <see cref="DateTime"/> value has no time part, "0:00:00" is returned.
    /// </returns>
    public static string TimePartOnly(this DateTime target)
    {
        var dateAndTime = target.Split();
        var existTimePart = dateAndTime.Length >= 2;

        if (existTimePart)
        {
            return dateAndTime.Length == 2
                ? dateAndTime[1]
                : $"{dateAndTime[1]} {dateAndTime[2]}";
        }

        return "0:00:00";
    }

    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> value is between the provided start and end <see cref="DateTime"/> values.
    /// </summary>
    /// <param name="timeToCompare">The <see cref="DateTime"/> value to check for being between <paramref name="beginTime"/> and <paramref name="endTime"/>.</param>
    /// <param name="beginTime">The start <see cref="DateTime"/> value of the range (inclusive).</param>
    /// <param name="endTime">The end <see cref="DateTime"/> value of the range (exclusive).</param>
    /// <returns>
    /// <see langword="true"/> if the specified <see cref="DateTime"/> value is between <paramref name="beginTime"/> and <paramref name="endTime"/>; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="beginTime"/> is greater than or equal to <paramref name="endTime"/>.</exception>
    public static bool IsBetween(this DateTime timeToCompare, DateTime beginTime, DateTime endTime)
    {
        return timeToCompare >= beginTime
               && timeToCompare <= endTime;
    }

}
