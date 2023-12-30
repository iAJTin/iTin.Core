
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with collections of <see cref="TimeSpan"/> objects.
/// </summary> 
public static class TimeSpanExtensions
{
    /// <summary>
    /// Returns the total time calculated by summing all the durations in the collection.
    /// </summary>
    /// <param name="durations">The collection of <see cref="TimeSpan"/> objects to calculate the total time from.</param>
    /// <returns>
    /// A <see cref="TimeSpan"/> representing the total time calculated by summing all the durations in the collection.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method calculates the total time by summing the <see cref="TimeSpan.TotalSeconds"/> of each duration in the collection.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input collection (<paramref name="durations"/>) is <see langword="null"/>.</exception>
    public static TimeSpan TotalTime(this IEnumerable<TimeSpan> durations)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(TimeSpanExtensions).Assembly.GetName().Name}, v{typeof(TimeSpanExtensions).Assembly.GetName().Version}, Namespace: {typeof(TimeSpanExtensions).Namespace}, Class: {nameof(TimeSpanExtensions)}");
        Logger.Instance.Debug(" Returns total time");
        Logger.Instance.Debug($" > Signature: ({typeof(TimeSpan)}) TotalTime(this {typeof(IEnumerable<TimeSpan>)})");
        Logger.Instance.Debug($"   > durations: {durations.Count()} entries");

        var result = new TimeSpan(0, 0, durations.Sum(t => (int)t.TotalSeconds));
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="TimeSpan"/> object into a string with a short format.
    /// </summary>
    /// <param name="target">The <see cref="TimeSpan"/> object to convert.</param>
    /// <returns>
    /// A string representation of the <see cref="TimeSpan"/> object with the format "HH:mm".
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method formats the <paramref name="target"/> TimeSpan object as "HH:mm".
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input TimeSpan (<paramref name="target"/>) is <see langword="null"/>.</exception>
    public static string ToShortFormat(this TimeSpan target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(TimeSpanExtensions).Assembly.GetName().Name}, v{typeof(TimeSpanExtensions).Assembly.GetName().Version}, Namespace: {typeof(TimeSpanExtensions).Namespace}, Class: {nameof(TimeSpanExtensions)}");
        Logger.Instance.Debug($" Converts a {typeof(TimeSpan)} object into dd'd' HH'h' MM'm' ss's' or HH'h' MM'm' ss's' or MM'm' ss's' string");
        Logger.Instance.Debug($" > Signature: ({typeof(TimeSpan)}) TotalTime(this {typeof(IEnumerable<TimeSpan>)})");
        Logger.Instance.Debug($"   > target: {target}");

        string result = string.Format(CultureInfo.InvariantCulture, "{0:00}:{1:00}", target.Hours, target.Minutes);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }
}
