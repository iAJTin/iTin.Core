
using System;
using System.Collections.Generic;
using System.Linq;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with arrays.
/// </summary>
public static class ArrayExtensions
{
    #region public static methods

    /// <summary>
    /// Appends a single element to the end of the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="item">The element to append to the array.</param>
    /// <returns>
    /// A new array that contains the original elements followed by the appended element.
    /// </returns>
    public static T[] Append<T>(this T[] array, T item) => InsertAt(array, array.Length, item);

    /// <summary>
    /// Appends an array of elements to the end of the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="items">The array of elements to append to the array.</param>
    /// <returns>
    /// A new array that contains the original elements followed by the appended elements.
    /// </returns>
    public static T[] Append<T>(this T[] array, T[] items) => InsertAt(array, array.Length, items);

    /// <summary>
    /// Copies a set of elements from the array starting from the specified position and length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="start">The index from which to start copying elements.</param>
    /// <param name="length">The number of elements to copy.</param>
    /// <returns>
    /// A new array containing the copied elements from the specified position and length.
    /// </returns>
    public static T[] Copy<T>(this T[] array, int start, int length)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ArrayExtensions).Assembly.GetName().Name}, v{typeof(ArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ArrayExtensions).Namespace}, Class: {nameof(ArrayExtensions)}");
        Logger.Instance.Debug(" Copy a set of elements from an array from the indicated position and length");
        Logger.Instance.Debug($" > Signature: ({typeof(T[])}) Copy<{typeof(T)})>(this {typeof(T[])}, {typeof(int)}, {typeof(int)})");
        Logger.Instance.Debug($"   > array: {array.Length} items");
        Logger.Instance.Debug($"   > start: {start}");
        Logger.Instance.Debug($"   > length: {length}");

        // It's ok for 'start' to equal 'array.Length'.  In that case you'll
        // just get an empty array back.
        //Debug.Assert(start >= 0);
        //Debug.Assert(start <= array.Length);

        if (start + length > array.Length)
        {
            length = array.Length - start;
        }

        T[] newArray = new T[length];
        Array.Copy(array, start, newArray, 0, length);
        return newArray;
    }

    /// <summary>
    /// Inserts an element into the array at the specified position.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="position">The index at which to insert the element.</param>
    /// <param name="item">The element to insert into the array.</param>
    /// <returns>
    /// A new array with the specified element inserted at the indicated position.
    /// </returns>
    public static T[] InsertAt<T>(this T[] array, int position, T item)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ArrayExtensions).Assembly.GetName().Name}, v{typeof(ArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ArrayExtensions).Namespace}, Class: {nameof(ArrayExtensions)}");
        Logger.Instance.Debug(" Insert an element in the array at the indicated position");
        Logger.Instance.Debug($" > Signature: ({typeof(T[])}) InsertAt<{typeof(T)})>(this {typeof(T[])}, {typeof(int)}, {typeof(T)})");
        Logger.Instance.Debug($"   > array: {array.Length} items");
        Logger.Instance.Debug($"   > position: {position}");
        Logger.Instance.Debug($"   > item: {item}");

        T[] newArray = new T[array.Length + 1];
        if (position > 0)
        {
            Array.Copy(array, newArray, position);
        }

        if (position < array.Length)
        {
            Array.Copy(array, position, newArray, position + 1, array.Length - position);
        }

        newArray[position] = item;
        return newArray;
    }

    /// <summary>
    /// Inserts an array of elements into the array at the specified position.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="position">The index at which to insert the array of elements.</param>
    /// <param name="items">The array of elements to insert into the array.</param>
    /// <returns>
    /// A new array with the specified array of elements inserted at the indicated position.
    /// </returns>
    public static T[] InsertAt<T>(this T[] array, int position, T[] items)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ArrayExtensions).Assembly.GetName().Name}, v{typeof(ArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ArrayExtensions).Namespace}, Class: {nameof(ArrayExtensions)}");
        Logger.Instance.Debug(" Insert an array of elements in the array from the indicated position");
        Logger.Instance.Debug($" > Signature: ({typeof(T[])}) InsertAt<{typeof(T)})>(this {typeof(T[])}, {typeof(int)}, {typeof(T[])})");
        Logger.Instance.Debug($"   > array: {array.Length} items");
        Logger.Instance.Debug($"   > position: {position}");
        Logger.Instance.Debug($"   > items: {array.Length} items");

        T[] newArray = new T[array.Length + items.Length];
        if (position > 0)
        {
            Array.Copy(array, newArray, position);
        }

        if (position < array.Length)
        {
            Array.Copy(array, position, newArray, position + items.Length, array.Length - position);
        }

        items.CopyTo(newArray, position);
        return newArray;
    }

    /// <summary>
    /// Removes a specified number of elements from the array starting at the specified position.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="position">The index at which to start removing elements.</param>
    /// <returns>
    /// A new array with one element removed starting from the indicated position.
    /// </returns>
    public static T[] RemoveAt<T>(this T[] array, int position) => RemoveAt(array, position, 1);

    /// <summary>
    /// Removes a specified number of elements from the array starting at the specified position.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="start">The index at which to start removing elements.</param>
    /// <param name="length">The number of elements to remove.</param>
    /// <returns>
    /// A new array with the specified number of elements removed starting from the indicated position.
    /// </returns>
    public static T[] RemoveAt<T>(this T[] array, int start, int length)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ArrayExtensions).Assembly.GetName().Name}, v{typeof(ArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ArrayExtensions).Namespace}, Class: {nameof(ArrayExtensions)}");
        Logger.Instance.Debug(" Remove an array of elements from an array from the indicated position and length");
        Logger.Instance.Debug($" > Signature: ({typeof(T[])}) RemoveAt<{typeof(T)})>(this {typeof(T[])}, {typeof(int)}, {typeof(int)})");
        Logger.Instance.Debug($"   > array: {array.Length} items");
        Logger.Instance.Debug($"   > start: {start}");
        Logger.Instance.Debug($"   > length: {length}");

        if (start + length > array.Length)
        {
            length = array.Length - start;
        }

        T[] newArray = new T[array.Length - length];
        if (start > 0)
        {
            Array.Copy(array, newArray, start);
        }

        if (start < newArray.Length)
        {
            Array.Copy(array, start + length, newArray, start, newArray.Length - start);
        }

        return newArray;
    }

    /// <summary>
    /// Replaces an element in the array at the indicated position.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="position">The index at which to replace the element.</param>
    /// <param name="item">The new element to replace at the specified position.</param>
    /// <returns>
    /// A new array with the specified element replaced at the indicated position.
    /// </returns>
    public static T[] ReplaceAt<T>(this T[] array, int position, T item)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ArrayExtensions).Assembly.GetName().Name}, v{typeof(ArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ArrayExtensions).Namespace}, Class: {nameof(ArrayExtensions)}");
        Logger.Instance.Debug(" Replace an element in the array at the indicated position");
        Logger.Instance.Debug($" > Signature: ({typeof(T[])}) ReplaceAt<{typeof(T)})>(this {typeof(T[])}, {typeof(int)}, {typeof(T)})");
        Logger.Instance.Debug($"   > array: {array.Length} items");
        Logger.Instance.Debug($"   > position: {position}");
        Logger.Instance.Debug($"   > item: {item}");

        T[] newArray = new T[array.Length];
        Array.Copy(array, newArray, array.Length);
        newArray[position] = item;
        return newArray;
    }

    /// <summary>
    /// Replaces a specified length of elements in the array at the indicated position with a new array of items.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="position">The index at which to start replacing elements.</param>
    /// <param name="length">The number of elements to replace.</param>
    /// <param name="items">The new array of items to insert at the specified position.</param>
    /// <returns>
    /// A new array with the specified length of elements replaced at the indicated position.
    /// </returns>
    public static T[] ReplaceAt<T>(this T[] array, int position, int length, T[] items) => InsertAt(RemoveAt(array, position, length), position, items);

    /// <summary>
    /// Slices the array into multiple arrays with a specified maximum number of elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="source">The source array to be sliced.</param>
    /// <param name="maxResultElements">The maximum number of elements in each sliced array.</param>
    /// <returns>
    /// A <see cref="IEnumerable{T}"/> of arrays, each containing a maximum of <paramref name="maxResultElements"/> elements.
    /// </returns>
    public static IEnumerable<T[]> SliceArray<T>(this T[] source, int maxResultElements)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ArrayExtensions).Assembly.GetName().Name}, v{typeof(ArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ArrayExtensions).Namespace}, Class: {nameof(ArrayExtensions)}");
        Logger.Instance.Debug(" Slice array");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<T>)}) SliceArray<{typeof(T)})>(this {typeof(T[])}, {typeof(int)})");
        Logger.Instance.Debug($"   > array: {source.Length} items");
        Logger.Instance.Debug($"   > maxResultElements: {maxResultElements}");

        int numberOfArrays = source.Length / maxResultElements;
        if (maxResultElements * numberOfArrays < source.Length)
        {
            numberOfArrays++;
        }

        T[][] target = new T[numberOfArrays][];
        for (int index = 0; index < numberOfArrays; index++)
        {
            int elementsInThisArray = Math.Min(maxResultElements, source.Length - index * maxResultElements);
            target[index] = new T[elementsInThisArray];
            Array.Copy(source, index * maxResultElements, target[index], 0, elementsInThisArray);
        }

        return target.ToList();
    }

    #endregion

    #region internal static methods

    internal static void ReverseContents<T>(this T[] array) => ReverseContents(array, 0, array.Length);

    internal static void ReverseContents<T>(this T[] array, int start, int count)
    {
        int end = start + count - 1;
        for (int i = start, j = end; i < j; i++, j--)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    #endregion
}
