
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with enumerable collections.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Converts a collection of bytes to a collection of hexadecimal strings.
    /// </summary>
    /// <param name="value">An IEnumerable of bytes to be converted to hexadecimal strings.</param>
    /// <returns>
    /// An IEnumerable of strings where each string represents the hexadecimal representation of a byte in the input collection.
    /// </returns>
    public static IEnumerable<string> AsHexadecimal(this IEnumerable<byte> value) => new ReadOnlyCollection<string>(value.Select(item => $"{item:x2}").ToList());

    /// <summary>
    /// Calculates the average of each element at the same position across multiple series.
    /// </summary>
    /// <param name="series">An IEnumerable of IEnumerable of int representing the series to calculate averages from.</param>
    /// <returns>
    /// An IEnumerable of double? containing the calculated averages for each position.<br/>
    /// If a position has <see langword="null"/> values in any series, the result for that position will be <see langword="null"/>.
    /// </returns>
    /// <remarks>
    /// The method assumes that all series have the same length.
    /// </remarks>
    public static IEnumerable<double?> Average(this IEnumerable<IEnumerable<int>> series)
    {
        var allSeries = series.ToList();
        var averages = new List<double?>();
        for (var i = 0; i != allSeries.First().Count(); ++i)
        {
            averages.Add(allSeries.Average(serie => serie.ElementAt(i)));
        }

        return averages;
    }

    /// <summary>
    /// Calculates the average of each element at the same position across multiple series.
    /// </summary>
    /// <param name="series">An IEnumerable of IEnumerable of float representing the series to calculate averages from.</param>
    /// <returns>
    /// An IEnumerable of float? containing the calculated averages for each position.<br/>
    /// If a position has <see langword="null"/> values in any series, the result for that position will be <see langword="null"/>.
    /// </returns>
    /// <remarks>
    /// The method assumes that all series have the same length.
    /// </remarks>
    public static IEnumerable<float?> Average(this IEnumerable<IEnumerable<float>> series)
    {
        var allSeries = series.ToList();
        var averages = new List<float?>();
        for (var i = 0; i != allSeries.First().Count(); ++i)
        {
            averages.Add(allSeries.Average(item => item.ElementAt(i)));
        }

        return averages;
    }

    /// <summary>
    /// Calculates the average of each element at the same position across multiple series.
    /// </summary>
    /// <param name="series">An IEnumerable of IEnumerable of long representing the series to calculate averages from.</param>
    /// <returns>
    /// An IEnumerable of double? containing the calculated averages for each position.<br/>
    /// If a position has <see langword="null"/> values in any series, the result for that position will be <see langword="null"/>.
    /// </returns>
    /// <remarks>
    /// The method assumes that all series have the same length.
    /// </remarks>
    public static IEnumerable<double?> Average(this IEnumerable<IEnumerable<long>> series)
    {
        var allSeries = series.ToList();
        var averages = new List<double?>();
        for (var i = 0; i != allSeries.First().Count(); ++i)
        {
            averages.Add(allSeries.Average(item => item.ElementAt(i)));
        }

        return averages;
    }

    /// <summary>
    /// Clones each element in the collection that implements the <see cref="ICloneable"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection to clone.</param>
    /// <returns>
    /// A new collection where each element is a clone of the corresponding element in the original collection.
    /// </returns>
    /// <remarks>
    /// This extension method clones each element in the collection that implements the <see cref="ICloneable"/> interface.<br/>
    /// The cloning process is performed by calling the <see cref="ICloneable.Clone"/> method on each element.<br/>
    /// Elements that do not implement <see cref="ICloneable"/> are not cloned and are included as they are in the new collection.
    /// </remarks>
    public static IEnumerable<T> Clone<T>(this IEnumerable<T> collection) where T : ICloneable
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Clones collection");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<T>)}) Clone<{typeof(T)}>(this {typeof(IEnumerable<T>)}) where {typeof(T)} : {typeof(ICloneable)}");
        Logger.Instance.Debug($"   > collection: {collection}");

        return collection.Select(item => (T) item.Clone());
    }

    /// <summary>
    /// Returns an empty enumerable if the input enumerable is <see langword="null"/>; otherwise, returns the original enumerable.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="data">The input enumerable.</param>
    /// <returns>
    /// An empty enumerable if the input enumerable is <see langword="null"/>; otherwise, the original enumerable.
    /// </returns>
    /// <remarks>
    /// This extension method is useful for preventing <see langword="null"/> reference exceptions when working with enumerable.<br/>
    /// It returns an empty enumerable if the input enumerable is <see langword="null"/>, allowing safe iteration or processing.
    /// </remarks>
    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> data) => data ?? Enumerable.Empty<T>();

    /// <summary>
    /// Moves a specified item to a new position within the enumerable collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="items">The enumerable collection to perform the exchange operation on.</param>
    /// <param name="item">The item to be moved to the new position.</param>
    /// <param name="newPosition">The new position to which the item should be moved.</param>
    /// <returns>
    /// A new <see cref="List{T}"/> containing the elements of the original collection with the specified item moved to the new position.
    /// </returns>
    /// <remarks>
    /// This extension method allows you to exchange the position of a specified item within the enumerable collection.<br/>
    /// If the collection is <see langword="null"/> or the specified item is<see langword="null"/>, the original collection is returned unchanged.<br/>
    /// If the new position is out of bounds, the original collection is returned unchanged.
    /// </remarks>
    public static List<T> ExchangeElement<T>(this IEnumerable<T> items, T item, int newPosition)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Moves specified item to new position");
        Logger.Instance.Debug($" > Signature: ({typeof(List<T>)}) ExchangeElement<{typeof(T)}>(this {typeof(IEnumerable<T>)})");
        Logger.Instance.Debug($"   > items: {items}");
        Logger.Instance.Debug($"   > item: {item}");
        Logger.Instance.Debug($"   > newPosition: {newPosition}");

        if (items == null)
        {
            return Array.Empty<T>().ToList();
        }

        var list = items.ToList();
        if (item == null)
        {
            return list;
        }

        if (newPosition > list.Count)
        {
            return list;
        }

        if (newPosition < 0)
        {
            return list;
        }

        list.Remove(item);
        list.Insert(newPosition, item);

        return list;
    }

    /// <summary>
    /// Extracts a subsequence of elements from the enumerable collection starting from a specified index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="sequence">The enumerable collection to extract elements from.</param>
    /// <param name="start">The index at which to start extracting elements.</param>
    /// <returns>
    /// An enumerable collection containing the extracted subsequence of elements.
    /// </returns>
    /// <remarks>
    /// This extension method allows you to extract a subsequence of elements from the enumerable collection
    /// starting from the specified index.
    /// </remarks>
    public static IEnumerable<T> Extract<T>(this IEnumerable<T> sequence, byte start)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Extracts the specified sequence");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<T>)}) Extract<{typeof(T)}>(this {typeof(IEnumerable<T>)}, {typeof(byte)})");
        Logger.Instance.Debug($"   > sequence: {sequence}");
        Logger.Instance.Debug($"   > start: {start}");

        return sequence.Skip(start);
    }

    /// <summary>
    /// Extracts a subsequence of elements from the enumerable collection, starting from a specified index and with a specified length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="sequence">The enumerable collection to extract elements from.</param>
    /// <param name="start">The index at which to start extracting elements.</param>
    /// <param name="length">The number of elements to extract from the starting index.</param>
    /// <returns>
    /// An enumerable collection containing the extracted subsequence of elements.
    /// </returns>
    /// <remarks>
    /// This extension method allows you to extract a subsequence of elements from the enumerable collection
    /// starting from the specified index and with the specified length. 
    /// </remarks>
    public static IEnumerable<T> Extract<T>(this IEnumerable<T> sequence, byte start, byte length)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Extracts the specified sequence");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<T>)}) Extract<{typeof(T)}>(this {typeof(IEnumerable<T>)}, {typeof(byte)}, {typeof(byte)})");
        Logger.Instance.Debug($"   > sequence: {sequence}");
        Logger.Instance.Debug($"   > start: {start}");
        Logger.Instance.Debug($"   > length: {length}");

        return sequence
            .Skip(start)
            .TakeWhile((_, index) => index < length);
    }

    /// <summary>
    /// Extracts a subsequence of elements from the enumerable collection, starting from a specified index and with a specified length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="sequence">The enumerable collection to extract elements from.</param>
    /// <param name="start">The index at which to start extracting elements.</param>
    /// <param name="length">The number of elements to extract from the starting index.</param>
    /// <returns>
    /// An enumerable collection containing the extracted subsequence of elements.
    /// </returns>
    /// <remarks>
    /// This extension method allows you to extract a subsequence of elements from the enumerable collection
    /// starting from the specified index and with the specified length.
    /// </remarks>
    public static IEnumerable<T> Extract<T>(this IEnumerable<T> sequence, int start, int length)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Extracts the specified sequence");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<T>)}) Extract<{typeof(T)}>(this {typeof(IEnumerable<T>)}, {typeof(byte)}, {typeof(int)})");
        Logger.Instance.Debug($"   > sequence: {sequence}");
        Logger.Instance.Debug($"   > start: {start}");
        Logger.Instance.Debug($"   > length: {length}");

        return sequence
            .Skip(start)
            .TakeWhile((_, index) => index < length);
    }

    /// <summary>
    /// Executes the specified action for each element in the enumerable collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="source">The enumerable collection to iterate over.</param>
    /// <param name="action">The action to be executed for each element.</param>
    /// <remarks>
    /// This extension method provides a convenient way to perform an action for each element
    /// in the enumerable collection without the need for an explicit foreach loop.
    /// </remarks>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Executes an action for every item in the collection");
        Logger.Instance.Debug($" > Signature: ({typeof(List<T>)}) ForEach<{typeof(T)}>(this {typeof(IEnumerable<T>)}, {typeof(Action<T>)})");
        Logger.Instance.Debug($"   > source: {source}");
        Logger.Instance.Debug($"   > action: {action}");

        foreach (var item in source)
        {
            action(item);
        }
    }

    /// <summary>
    /// Gets a list of duplicate elements from the specified enumerable collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="source">The enumerable collection to retrieve duplicates from.</param>
    /// <returns>
    /// A list containing duplicate elements from the specified collection.
    /// </returns>
    /// <remarks>
    /// This method uses a hash set to track unique elements and identify duplicates.
    /// </remarks>
    public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> source)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug(" Assembly: iTin.Core, Namespace: iTin.Core, Class: EnumerableExtensions");
        Logger.Instance.Debug($" Gets the duplicates");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<T>)}) GetDuplicates<{typeof(T)}>(this {typeof(IEnumerable<T>)})");
        Logger.Instance.Debug($"   > source: {source}");

        var itemsSeen = new HashSet<T>();
        var itemsYielded = new HashSet<T>();

        foreach (var item in source)
        {
            if (itemsSeen.Add(item))
            {
                continue;
            }

            if (itemsYielded.Add(item))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Determines whether the specified enumerable collection has duplicates.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="source">The enumerable collection to check for duplicates.</param>
    /// <returns>
    /// <see langword="true"/> if the collection contains duplicates; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks whether the specified enumerable collection has duplicates by utilizing the <see cref="GetDuplicates{T}(IEnumerable{T})"/> method.
    /// </remarks>
    public static bool HasDuplicates<T>(this IEnumerable<T> source)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Gets the duplicates");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<T>)}) HasDuplicates<{typeof(T)}>(this {typeof(IEnumerable<T>)})");
        Logger.Instance.Debug($"   > source: {source}");

        IEnumerable<T> duplicates = source.GetDuplicates();
        return duplicates.Any();
    }

    /// <summary>
    /// Checks whether the specified enumerable collection is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
    /// <param name="items">The enumerable collection to check for <see langword="null"/> or emptiness.</param>
    /// <returns>
    /// <see langword="true"/> if the collection is <see langword="null"/> or contains no elements; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks whether the specified enumerable collection is <see langword="null"/> or empty.
    /// </remarks>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> items) => items == null || !items.Any();

    /// <summary>
    /// Pivots the specified collection of objects based on two key selectors and an aggregation function.
    /// </summary>
    /// <typeparam name="TSource">The type of objects in the collection.</typeparam>
    /// <typeparam name="TFirstKey">The type of the first key.</typeparam>
    /// <typeparam name="TSecondKey">The type of the second key.</typeparam>
    /// <typeparam name="TValue">The type of the aggregated value.</typeparam>
    /// <param name="source">The collection of objects to pivot.</param>
    /// <param name="firstKeySelector">A function to extract the first key from each object.</param>
    /// <param name="secondKeySelector">A function to extract the second key from each object.</param>
    /// <param name="aggregate">A function to aggregate values for each combination of first and second keys.</param>
    /// <returns>
    /// A <see cref="Dictionary{TFirstKey, Dictionary{TSecondKey, TValue}}"/> representing the pivoted collection.
    /// </returns>
    /// <remarks>
    /// This method pivots the collection of objects based on two key selectors and an aggregation function.<br/>
    /// It creates a dictionary where the first-level keys are obtained using the <paramref name="firstKeySelector"/>
    /// and the second-level keys are obtained using the <paramref name="secondKeySelector"/>.<br/>
    /// The values are aggregated using the specified <paramref name="aggregate"/> function.
    /// </remarks>
    public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TFirstKey> firstKeySelector, Func<TSource, TSecondKey> secondKeySelector, Func<IEnumerable<TSource>, TValue> aggregate)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Pivots the specified first key selector");
        Logger.Instance.Debug($" > Signature: ({typeof(Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>)}) Pivot(this {typeof(IEnumerable<TSource>)}, {typeof(Func<TSource, TFirstKey>)}, {typeof(Func<TSource, TSecondKey>)}, {typeof(Func<IEnumerable<TSource>, TValue>)})");
        Logger.Instance.Debug($"   > source: {source}");
        Logger.Instance.Debug($"   > firstKeySelector: {firstKeySelector}");
        Logger.Instance.Debug($"   > secondKeySelector: {secondKeySelector}");
        Logger.Instance.Debug($"   > aggregate: {aggregate}");

        var retVal = new Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>();

        var l = source.ToLookup(firstKeySelector);
        foreach (var item in l)
        {
            var dict = new Dictionary<TSecondKey, TValue>();
            retVal.Add(item.Key, dict);
            var subdict = item.ToLookup(secondKeySelector);
            foreach (var subitem in subdict)
            {
                dict.Add(subitem.Key, aggregate(subitem));
            }
        }

        return retVal;
    }

    /// <summary>
    /// Converts an <see cref="IEnumerable"/> collection of objects into a <see cref="DataTable"/> with the specified table name.
    /// </summary>
    /// <typeparam name="T">The type of objects in the collection.</typeparam>
    /// <param name="items">The <see cref="IEnumerable"/> collection of objects to convert.</param>
    /// <param name="name">The name of the <see cref="DataTable"/>.</param>
    /// <returns>
    /// A <see cref="DataTable"/> representing the collection of objects with columns named after the object properties.
    /// </returns>
    /// <remarks>
    /// This method creates a new <see cref="DataTable"/> with the specified name. It then iterates through the collection
    /// of objects and adds rows to the table, with each row containing the property values of the corresponding object.
    /// </remarks>
    public static DataTable ToDataTable<T>(this IEnumerable items, string name)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Converts an enumeration of groupings into a Dictionary of those groupings");
        Logger.Instance.Debug($" > Signature: ({typeof(DataTable)}) ToDataTable(this {typeof(IEnumerable)}, {typeof(string)})");
        Logger.Instance.Debug($"   > items: {items}");
        Logger.Instance.Debug($"   > name: {name}");

        var table = new DataTable(name);
        var properties = TypeDescriptor.GetProperties(typeof(T));
        foreach (PropertyDescriptor prop in properties)
        {
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        var list = items.Cast<T>();
        foreach (var item in list)
        {
            var row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
            {
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            }

            table.Rows.Add(row);
        }

        return table;
    }

    /// <summary>
    /// Converts an enumeration of groupings into a <see cref="Dictionary{TKey, TValue}"/> where each grouping key is the key
    /// in the dictionary, and the corresponding value is a <see cref="List{T}"/> containing the elements in that grouping.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the groupings.</typeparam>
    /// <typeparam name="TValue">The type of the elements in the groupings.</typeparam>
    /// <param name="groupings">The enumeration of groupings to convert.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TValue}"/> where each grouping key is the key in the dictionary, and the corresponding
    /// value is a <see cref="List{T}"/> containing the elements in that grouping.
    /// </returns>
    /// <remarks>
    /// This method iterates through the input groupings and creates a new <see cref="Dictionary{TKey, TValue}"/> where each grouping key
    /// is the key in the dictionary, and the corresponding value is a <see cref="List{T}"/> containing the elements in that grouping.
    /// </remarks>
    public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Converts an enumeration of groupings into a Dictionary of those groupings");
        Logger.Instance.Debug($" > Signature: ({typeof(Dictionary<TKey, List<TValue>>)}) ToDictionary(this {typeof(IEnumerable<IGrouping<TKey, TValue>>)})");
        Logger.Instance.Debug($"   > groupings: {groupings}");

        return groupings.ToDictionary(group => group.Key, group => group.ToList());
    }

    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> to an <see cref="ObservableCollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="source">The source <see cref="IEnumerable{T}"/> to convert.</param>
    /// <returns>
    /// An <see cref="ObservableCollection{T}"/> containing the elements from the source <see cref="IEnumerable{T}"/>.
    /// </returns>
    /// <remarks>
    /// This method creates a new <see cref="ObservableCollection{T}"/> and adds each element from the source <see cref="IEnumerable{T}"/>
    /// to the new collection.
    /// </remarks>
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(EnumerableExtensions).Assembly.GetName().Name}, v{typeof(EnumerableExtensions).Assembly.GetName().Version}, Namespace: {typeof(EnumerableExtensions).Namespace}, Class: {nameof(EnumerableExtensions)}");
        Logger.Instance.Debug($" Creates a new observable collection from an {typeof(IEnumerable<T>)}");
        Logger.Instance.Debug($" > Signature: ({typeof(ObservableCollection<T>)}) ToObservableCollection<{typeof(T)}>(this {typeof(IEnumerable<T>)})");
        Logger.Instance.Debug($"   > source: {source}");

        return new ObservableCollection<T>(source);
    }

    /// <summary>
    /// Wraps a single item in an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    /// <param name="item">The item to wrap in the <see cref="IEnumerable{T}"/>.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing only the specified item.
    /// </returns>
    /// <remarks>
    /// This method is useful when you need to treat a single item as an enumerable sequence.
    /// </remarks>
    public static IEnumerable<T> Yield<T>(this T item)
    {
        yield return item;
    }
}
