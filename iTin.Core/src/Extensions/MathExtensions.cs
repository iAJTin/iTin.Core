
using iTin.Logging;

namespace iTin.Core.Helpers;

/// <summary>
/// Provides extension methods for conversion operations and other common mathematical functions.
/// </summary>
public static class MathExtensions
{
    /// <summary>
    /// Gets a value indicating whether the parameter is odd.
    /// </summary>
    /// <param name="value">The integer value to check.</param>
    /// <returns>
    /// <see langword="true"/> if the value is odd; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsOdd(this int value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(MathExtensions).Assembly.GetName().Name}, v{typeof(MathExtensions).Assembly.GetName().Version}, Namespace: {typeof(MathExtensions).Namespace}, Class: {nameof(MathExtensions)}");
        Logger.Instance.Debug(" Gets a value indicating whether the parameter is odd");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsOdd(this {typeof(int)})");
        Logger.Instance.Debug($"   > value: {value}");

        bool result = value % 2 != 0;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Gets a value indicating whether the parameter is odd.
    /// </summary>
    /// <param name="value">The unsigned integer value to check.</param>
    /// <returns>
    /// <see langword="true"/> if the value is odd; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsOdd(this uint value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(MathExtensions).Assembly.GetName().Name}, v{typeof(MathExtensions).Assembly.GetName().Version}, Namespace: {typeof(MathExtensions).Namespace}, Class: {nameof(MathExtensions)}");
        Logger.Instance.Debug(" Gets a value indicating whether the parameter is odd");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsOdd(this {typeof(uint)})");
        Logger.Instance.Debug($"   > value: {value}");

        bool result = value % 2 != 0;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Gets a value indicating whether the parameter is odd.
    /// </summary>
    /// <param name="value">The short integer value to check.</param>
    /// <returns>
    /// <see langword="true"/> if the value is odd; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsOdd(this short value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(MathExtensions).Assembly.GetName().Name}, v{typeof(MathExtensions).Assembly.GetName().Version}, Namespace: {typeof(MathExtensions).Namespace}, Class: {nameof(MathExtensions)}");
        Logger.Instance.Debug(" Gets a value indicating whether the parametre is odd");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsOdd(this {typeof(short)})");
        Logger.Instance.Debug($"   > value: {value}");

        bool result = value % 2 != 0;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Gets a value indicating whether the parameter is odd.
    /// </summary>
    /// <param name="value">The unsigned short integer value to check.</param>
    /// <returns>
    /// <see langword="true"/> if the value is odd; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsOdd(this ushort value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(MathExtensions).Assembly.GetName().Name}, v{typeof(MathExtensions).Assembly.GetName().Version}, Namespace: {typeof(MathExtensions).Namespace}, Class: {nameof(MathExtensions)}");
        Logger.Instance.Debug(" Gets a value indicating whether the parametre is odd");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsOdd(this {typeof(ushort)})");
        Logger.Instance.Debug($"   > value: {value}");

        bool result = value % 2 != 0;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Gets a value indicating whether the parameter is odd.
    /// </summary>
    /// <param name="value">The long value to check.</param>
    /// <returns>
    /// <see langword="true"/> if the value is odd; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsOdd(this long value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(MathExtensions).Assembly.GetName().Name}, v{typeof(MathExtensions).Assembly.GetName().Version}, Namespace: {typeof(MathExtensions).Namespace}, Class: {nameof(MathExtensions)}");
        Logger.Instance.Debug(" Gets a value indicating whether the parametre is odd");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsOdd(this {typeof(long)})");
        Logger.Instance.Debug($"   > value: {value}");

        bool result = value % 2 != 0;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Gets a value indicating whether the parameter is odd.
    /// </summary>
    /// <param name="value">The unsigned long integer value to check.</param>
    /// <returns>
    /// <see langword="true"/> if the value is odd; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsOdd(this ulong value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(MathExtensions).Assembly.GetName().Name}, v{typeof(MathExtensions).Assembly.GetName().Version}, Namespace: {typeof(MathExtensions).Namespace}, Class: {nameof(MathExtensions)}");
        Logger.Instance.Debug(" Gets a value indicating whether the parametre is odd");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsOdd(this {typeof(ulong)})");
        Logger.Instance.Debug($"   > value: {value}");

        bool result = value % 2 != 0;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }
}
