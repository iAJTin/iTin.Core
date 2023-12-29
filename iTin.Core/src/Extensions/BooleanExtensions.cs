
using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods related to <see cref="bool"/> values.
/// </summary>
public static class BooleanExtensions
{
    /// <summary>
    /// Converts the specified boolean value to its binary equivalent value.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>
    /// A <see cref="byte"/> representing the binary equivalent of the boolean value.<br/>
    /// Returns 1 if the input is <see langword="true"/>, and 0 if the input is <see langword="false"/>.
    /// </returns>
    public static byte ToBinaryNotation(this bool value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(BooleanExtensions).Assembly.GetName().Name}, v{typeof(BooleanExtensions).Assembly.GetName().Version}, Namespace: {typeof(BooleanExtensions).Namespace}, Class: {nameof(BooleanExtensions)}");
        Logger.Instance.Debug(" Convert the value specified in its binary equivalent value");
        Logger.Instance.Debug($" > Signature: ({typeof(byte)}) ToBinaryNotation(this {typeof(bool)})");
        Logger.Instance.Debug($"   > value: {value}");

        var result = value ? (byte)1 : (byte)0;

        Logger.Instance.Debug($"  > Output: {result}");
        return result;
    }
}
