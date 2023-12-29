
using System;
using System.Collections.Generic;
using System.Linq;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for manipulating lists.
/// </summary>
public static class ListExtensions
{      
    /// <summary>
    /// Moves the specified item to a new position within the list.
    /// </summary>
    /// <param name="items">The target list.</param>
    /// <param name="item">The item to move.</param>
    /// <param name="newPosition">The new position within the list.</param>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <returns>
    /// The list with the item in the new position.
    /// </returns>
    public static List<T> MoveElementToPosition<T>(this List<T> items, T item, int newPosition)
    {
        if (items == null)
        {
            return null;
        }

        if (item == null)
        {
            return items;
        }

        if (newPosition > items.Count)
        {
            return items;
        }

        if (newPosition < 0)
        {
            return items;
        }

        items.Remove(item);
        items.Insert(newPosition, item);

        return items;
    }

    /// <summary>
    /// Returns the next item in the list after the specified current item.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="items">The target list.</param>
    /// <param name="current">The current item.</param>
    /// <returns>
    /// The next item in the list or <see langword="null"/> if the current item is the last.
    /// </returns>
    public static T? GetNext<T>(this List<T> items, T current) where T : struct
    {
        Logger.Instance.Debug("External Call");
        Logger.Instance.Info("  Returns the next item on the list from the specified current. Will return null if the current is the last");
        Logger.Instance.Info("  > Library: iTin.Core");
        Logger.Instance.Info("  > Class: ListExtensions");
        Logger.Instance.Info("  > Method: GetNext<T>(this List<T>, T)");
        Logger.Instance.Info("  > Output: T?");

        if (items.IsNullOrEmpty())
        {
            return null;
        }

        var length = items.Count();
        var index = items.LastIndexOf(current);
        if (index >= length - 1)
        {
            return null;
        }

        return items[index + 1];
    }

    /// <summary>
    /// Returns the previous item in the list before the specified current item.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="items">The target list.</param>
    /// <param name="current">The current item.</param>
    /// <returns>
    /// The previous item in the list or <see langword="null"/> if the current item is the first.
    /// </returns>
    public static T? GetPrev<T>(this List<T> items, T current) where T : struct
    {
        Logger.Instance.Debug("External Call");
        Logger.Instance.Info("  Returns the previous item on the list from the specified current. Will return null if the current is the first");
        Logger.Instance.Info("  > Library: iTin.Core");
        Logger.Instance.Info("  > Class: ListExtensions");
        Logger.Instance.Info("  > Method: GetPrev<T>(this List<T>, T)");
        Logger.Instance.Info("  > Output: T?");

        if (items.IsNullOrEmpty())
        {
            return null;
        }

        var index = items.IndexOf(current);

        if (index <= 0)
        {
            return null;
        }

        return items[index - 1];
    }

    /// <summary>
    /// Returns the next item in the list after the specified current item.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="items">The target list.</param>
    /// <param name="current">The current item.</param>
    /// <returns>
    /// The next item in the list or <see langword="null"/> if the current item is the last.
    /// </returns>
    public static T GetNextObject<T>(this List<T> items, T current) where T : class
    {
        Logger.Instance.Debug("External Call");
        Logger.Instance.Info("  Returns the next item on the list from the specified current. Will return null if the current is the last");
        Logger.Instance.Info("  > Library: iTin.Core");
        Logger.Instance.Info("  > Class: ListExtensions");
        Logger.Instance.Info("  > Method: GetNextObject<T>(this List<T>, T)");
        Logger.Instance.Info("  > Output: T");

        if (items.IsNullOrEmpty())
        {
            return null;
        }

        var length = items.Count;
        var index = items.LastIndexOf(current);
        if (index >= length - 1)
        {
            return null;
        }

        return items[index + 1];
    }

    /// <summary>
    /// Returns the previous item in the list before the specified current item.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="items">The target list.</param>
    /// <param name="current">The current item.</param>
    /// <returns>
    /// The previous item in the list or <see langword="null"/> if the current item is the first.
    /// </returns>
    public static T GetPrevObject<T>(this List<T> items, T current) where T : class
    {
        Logger.Instance.Debug("External Call");
        Logger.Instance.Info("  Returns the previous item on the list from the specified current. Will return null if the current is the first");
        Logger.Instance.Info("  > Library: iTin.Core");
        Logger.Instance.Info("  > Class: ListExtensions");
        Logger.Instance.Info("  > Method: GetPrevObject<T>(this List<T>, T)");
        Logger.Instance.Info("  > Output: T");

        if (items.IsNullOrEmpty())
        {
            return null;
        }

        var index = items.IndexOf(current);
        if (index <= 0)
        {
            return null;
        }

        return items[index - 1];
    }

    /// <summary>
    /// Returns a valid index to use in the specified list.
    /// </summary>
    /// <typeparam name="T">Type element.</typeparam>
    /// <param name="items">Target list.</param>
    /// <param name="index">Reference index.</param>
    /// <returns>
    /// A valid index within the list.
    /// </returns>
    public static int GetValidIndex<T>(this List<T> items, int index) => Math.Max(0, Math.Min(index, items.Count - 1));

    /// <summary>
    /// Determines if the specified value is a valid index in the list.
    /// </summary>
    /// <typeparam name="T">Type element.</typeparam>
    /// <param name="items">Target list.</param>
    /// <param name="index">Value to test.</param>
    /// <returns>
    /// <see langword="true"/> if it's a valid index; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsValidIndex<T>(this IList<T> items, int index) => items != null && index >= 0 && index < items.Count;

    /// <summary>
    /// Try returns the item at the specified index. 
    /// If the index is not valid, the value is set to <see langword="null"/> or default value.
    /// </summary>
    /// <typeparam name="T">Type element.</typeparam>
    /// <param name="items">Target list.</param>
    /// <param name="index">Reference index.</param>
    /// <param name="value">Item.</param>
    /// <returns>
    /// <see langword="true"/> if the index is valid; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryGetValue<T>(this List<T> items, int index, ref T value)
    {
        if (!IsValidIndex(items, index))
        {
            return false;
        }

        value = items[index];

        return true;
    }
}
