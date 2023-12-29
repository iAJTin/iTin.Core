
using System;
using System.Collections.Generic;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with dictionaries.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Clones a <see cref="Dictionary{TKey, TValue}"/> by creating a new dictionary and cloning each value.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary, implementing <see cref="ICloneable"/>.</typeparam>
    /// <param name="original">The original <see cref="Dictionary{TKey, TValue}"/> to be cloned.</param>
    /// <returns>
    /// A new <see cref="Dictionary{TKey, TValue}"/> with cloned values from the original dictionary.
    /// </returns>
    /// <remarks>
    /// This method creates a new dictionary and clones each value in the original dictionary using the <see cref="ICloneable"/> interface.
    /// </remarks>
    public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> original) where TValue : ICloneable
    {
        var ret = new Dictionary<TKey, TValue>(original.Count, original.Comparer);
        foreach (var entry in original)
        {
            ret.Add(entry.Key, (TValue)entry.Value.Clone());
        }

        return ret;
    }

    /// <summary>
    /// Gets the value associated with the specified key. If the key is not found,
    /// adds a new instance of the value type to the dictionary with the specified key.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to operate on.</param>
    /// <param name="key">The key of the value to get or add.</param>
    /// <returns>
    /// The value associated with the specified key. If the key is not found, a new instance
    /// of the value type is added to the dictionary with the specified key.
    /// </returns>
    public static TValue GetOrAddNew<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key) where TValue : new()
    {
        if (source.TryGetValue(key, out var value))
        {
            return value;
        }

        value = new TValue();
        source.Add(key, value);

        return value;
    }

    /// <summary>
    /// Finds and returns the value associated with the specified key in the read-only dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="source">The read-only dictionary to operate on.</param>
    /// <param name="key">The key of the value to find.</param>
    /// <returns>
    /// The value associated with the specified key if found; otherwise, the default value of TValue.
    /// </returns>
    public static TValue Find<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, TKey key) => !source.TryGetValue(key, out var value) ? default : value;

    /// <summary>
    /// Determines whether two dictionaries are equal by comparing key-value pairs.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="first">The first dictionary to compare.</param>
    /// <param name="second">The second dictionary to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the dictionaries are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool DictionaryEqual<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second) => first.DictionaryEqual(second, null);

    /// <summary>
    /// Determines whether two dictionaries are equal by comparing key-value pairs using a specified comparer for the values.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="first">The first dictionary to compare.</param>
    /// <param name="second">The second dictionary to compare.</param>
    /// <param name="valueComparer">The comparer to use for comparing values.</param>
    /// <returns>
    /// <see langword="true"/> if the dictionaries are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool DictionaryEqual<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second, IEqualityComparer<TValue> valueComparer)
    {
        if (first == second)
        {
            return true;
        }

        if (first == null || second == null)
        {
            return false;
        }

        if (first.Count != second.Count)
        {
            return false;
        }

        valueComparer ??= EqualityComparer<TValue>.Default;

        foreach (var kvp in first)
        {
            if (!second.TryGetValue(kvp.Key, out var secondValue))
            {
                return false;
            }

            if (!valueComparer.Equals(kvp.Value, secondValue))
            {
                return false;
            }
        }

        return true;
    }
}
