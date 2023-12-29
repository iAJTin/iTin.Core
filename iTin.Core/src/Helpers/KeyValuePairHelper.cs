
using System.Collections.Generic;

namespace iTin.Core.Helpers;

/// <summary>
/// Provides helper methods for working with <see cref="KeyValuePair{TK, TV}"/>.
/// </summary>
public static class KeyValuePairHelper
{
    /// <summary>
    /// Creates a new <see cref="KeyValuePair{TK, TV}"/> with the specified key and value.
    /// </summary>
    /// <typeparam name="TK">The type of the key.</typeparam>
    /// <typeparam name="TV">The type of the value.</typeparam>
    /// <param name="key">The key of the key-value pair.</param>
    /// <param name="value">The value of the key-value pair.</param>
    /// <returns>A new <see cref="KeyValuePair{TK, TV}"/> instance with the specified key and value.</returns>
    /// <remarks>
    /// This method creates and returns a new <see cref="KeyValuePair{TK, TV}"/> instance
    /// with the provided key and value.
    /// </remarks>
    public static KeyValuePair<TK, TV> Create<TK, TV>(TK key, TV value) => new(key, value);

    /// <summary>
    /// Deconstructs the specified <see cref="KeyValuePair{TK, TV}"/> into its key and value components.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="keyValuePair">The key-value pair to deconstruct.</param>
    /// <param name="key">When the method returns, contains the key of the key-value pair.</param>
    /// <param name="value">When the method returns, contains the value of the key-value pair.</param>
    /// <remarks>
    /// This extension method deconstructs the specified <see cref="KeyValuePair{TK, TV}"/>
    /// into its key and value components.
    /// </remarks>
    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> keyValuePair, out TKey key, out TValue value)
    {
        key = keyValuePair.Key;
        value = keyValuePair.Value;
    }
}
