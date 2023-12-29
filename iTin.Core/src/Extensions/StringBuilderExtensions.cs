
using System;
using System.Text;

using iTin.Core.Helpers;
using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with <see cref="StringBuilder"/> objects.
/// </summary>
public static class StringBuilderExtensions
{
    /// <summary>
    /// Clears the content of the specified <see cref="StringBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> to clear.</param>
    /// <remarks>
    /// This method sets the length of the string builder to zero, effectively clearing its content.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown if the provided <paramref name="builder"/> is <see langword="null"/>.</exception>
    public static void Clear(this StringBuilder builder)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringBuilderExtensions).Assembly.GetName().Name}, v{typeof(StringBuilderExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringBuilderExtensions).Namespace}, Class: {nameof(StringBuilderExtensions)}");
        Logger.Instance.Debug(" Clears the specified string builder");
        Logger.Instance.Debug($" > Signature: (void) Clear(this {typeof(StringBuilder)})");

        SentinelHelper.ArgumentNull(builder, nameof(builder));
        Logger.Instance.Debug($"   > builder: {builder.Length}");

        builder.Length = 0;
        Logger.Instance.Debug($"   builder set to {builder.Length}");
    }
}
