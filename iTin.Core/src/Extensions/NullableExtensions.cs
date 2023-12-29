
using System;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods related to <see cref="Nullable"/> structures.
/// </summary> 
public static class NullableExtensions
{
    /// <summary>
    /// Converts a nullable value to its non-null counterpart, or returns a default value if the original value is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="target">The nullable value.</param>
    /// <returns>
    /// The non-null value if the original value is not null; otherwise, the default value for the type.
    /// </returns>
    public static T AsNotNullValue<T>(this T? target) where T : struct => target.AsNotNullValue(default);

    /// <summary>
    /// Gets the value of the current <see cref="Nullable"/> object if it has been assigned a valid underlying value.
    /// If it is null, returns the specified default value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="target">The nullable value.</param>
    /// <param name="defaultValue">The default value to return if the original value is <see langword="null"/>.</param>
    /// <returns>
    /// The non-null value if the original value is not null; otherwise, the specified default value.
    /// </returns>
    public static T AsNotNullValue<T>(this T? target, T defaultValue) where T : struct
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(NullableExtensions).Assembly.GetName().Name}, v{typeof(NullableExtensions).Assembly.GetName().Version}, Namespace: {typeof(NullableExtensions).Namespace}, Class: {nameof(NullableExtensions)}");
        Logger.Instance.Debug($" Gets the value of the current {typeof(T?)} object if it has been assigned a valid underlying value. If is null (or Nothing in Visual Basic) returns yours default value defined for your type.");
        Logger.Instance.Debug($" > Signature: ({typeof(T)}) AsNotNullValue(this {typeof(T?)}, {typeof(T)})");

        T result = target ?? defaultValue;

        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }
}
