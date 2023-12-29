
using System;

namespace iTin.Core.Helpers;

/// <summary>
/// A utility class providing methods for converting time-related values.
/// </summary>
public static class TimeHelper
{
    /// <summary>
    /// Converts the specified number of minutes into a <see cref="TimeSpan"/>.
    /// </summary>
    /// <param name="minutes">The number of minutes to convert.</param>
    /// <returns>
    /// A <see cref="TimeSpan"/> equivalent to the specified number of minutes.
    /// </returns>
    /// <remarks>
    /// This method takes an integer representing the number of minutes and converts it
    /// into a <see cref="TimeSpan"/> value. The resulting <see cref="TimeSpan"/> represents
    /// the duration equivalent to the specified number of minutes.
    /// </remarks>
    public static TimeSpan ToTimeSpan(int minutes) => TimeSpan.FromMinutes(minutes);
}
