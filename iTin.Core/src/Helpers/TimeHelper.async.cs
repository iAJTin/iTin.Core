
using System;
using System.Threading.Tasks;

namespace iTin.Core.Helpers;

/// <summary>
/// A utility class providing asynchronous helper methods for delaying and executing actions.
/// </summary>
public static class TimeHelperAsync
{
    /// <summary>
    /// Delays the execution of an action asynchronously.
    /// </summary>
    /// <param name="delay">The delay duration in milliseconds.</param>
    /// <param name="action">The action to execute after the delay.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <remarks>
    /// This method asynchronously delays the execution of the specified action by the given duration.
    /// After the delay, the action is executed.
    /// </remarks>
    public static async Task DelayActionAsync(int delay, Action action)
    {
        await Task.Delay(delay);
        action();
    }
}
