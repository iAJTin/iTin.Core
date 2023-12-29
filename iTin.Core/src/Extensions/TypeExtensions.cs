
using System;
using System.Reflection;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with <see cref="Type"/> objects.<br/>
/// https://github.com/morrisjdev/FileContextCore/blob/master/FileContextCore/SharedTypeExtensions.cs
/// </summary> 
public static class TypeExtensions
{
    /// <summary>
    /// Gets the default value for the specified <see cref="Type"/>.
    /// </summary>
    /// <param name="target">The <see cref="Type"/> for which to get the default value.</param>
    /// <returns>
    /// The default value for the specified <see cref="Type"/>. If the type is a value type and not nullable,
    /// the default instance of the type is returned; otherwise, <see langword="null"/> is returned.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method returns the default value for a given <see cref="Type"/>.<br/>
    /// For value types that are not nullable, it creates and returns an instance of the type using <strong>Activator.CreateInstance</strong>.<br/>
    /// For reference types or nullable value types, <see langword="null"/> is returned.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input <see cref="Type"/> (<paramref name="target"/>) is <see langword="null"/>.</exception>
    public static object GetDefaultValue(this Type target)
    {
        if (target.IsValueType && Nullable.GetUnderlyingType(target) == null)
        {
            return Activator.CreateInstance(target);
        }

        return null;
    }

    /// <summary>
    /// Determines whether the specified <see cref="Type"/> is a nullable type.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> to check for nullable status.</param>
    /// <returns>
    /// <c>true</c> if the specified <see cref="Type"/> is nullable; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method checks whether the specified <see cref="Type"/> is a nullable type.<br/>
    /// A nullable type is either a reference type or a value type that has been wrapped in the <see cref="Nullable{T}"/> structure.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input <see cref="Type"/> (<paramref name="type"/>) is <see langword="null"/>.</exception>
    public static bool IsNullableType(this Type type)
    {
        var typeInfo = type.GetTypeInfo();

        return !typeInfo.IsValueType || typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
}
