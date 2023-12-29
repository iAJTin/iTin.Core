
namespace iTin.Core.Helpers;

/// <summary>
/// Helper class providing methods for type-related operations.
/// </summary>
public static class TypeHelper
{
    /// <summary>
    /// Converts an object to the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The target type to which the object is cast.</typeparam>
    /// <param name="value">The object to be converted.</param>
    /// <returns>
    /// The object cast to the specified type <typeparamref name="T"/>.
    /// </returns>
    /// <remarks>
    /// This generic method attempts to cast the provided object to the specified type <typeparamref name="T"/>.
    /// If the cast is successful, the object is returned as the target type; otherwise, an exception is thrown.
    /// </remarks>
    public static T ToType<T>(object value) => (T)value;
}
