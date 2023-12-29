
using System;
using System.Reflection;

using iTin.Logging;

namespace iTin.Core.Helpers;

/// <summary>
/// A helper class providing methods related to the current assembly.
/// </summary>
public static class AssemblyHelper
{
    /// <summary>
    /// Returns a <see cref="Uri"/> that contains the full path to the current assembly.
    /// </summary>
    /// <returns>
    /// A <see cref="Uri"/> that contains the full path to the current assembly.
    /// </returns>
    /// <remarks>
    /// This method retrieves the full path to the assembly of the <see cref="AssemblyHelper"/> class.
    /// </remarks>
    public static Uri GetFullAssemblyUri()
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(AssemblyHelper).Assembly.GetName().Name}, v{typeof(AssemblyHelper).Assembly.GetName().Version}, Namespace: {typeof(AssemblyHelper).Namespace}, Class: {nameof(AssemblyHelper)}");
        Logger.Instance.Debug($" Returns an {typeof(Uri)} that contains full path to current assembly");
        Logger.Instance.Debug($" > Signature: ({typeof(Uri)}) GetFullAssemblyUri()");

        var result = new Uri(Assembly.GetCallingAssembly().CodeBase);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }
}
