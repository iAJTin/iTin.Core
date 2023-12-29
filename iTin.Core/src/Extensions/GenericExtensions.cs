
using System;
using System.Collections.Generic;
using System.Linq;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides a set of generic extension methods.
/// </summary>
public static class GenericExtensions
{
    /// <summary>
    /// Executes a function if a specified predicate is <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the parameter and result.</typeparam>
    /// <param name="val">The value to be processed.</param>
    /// <param name="predicate">The predicate to evaluate.</param>
    /// <param name="func">The function to execute if the predicate is <see langword="true"/>.</param>
    /// <returns>
    /// The result of the function if the predicate is <see langword="true"/>; otherwise, the original value.
    /// </returns>
    /// <remarks>
    /// This method evaluates the specified predicate and, if <see langword="true"/>, executes the provided function with the given value.
    /// </remarks>
    public static T If<T>(this T val, Func<T, bool> predicate, Func<T, T> func)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(GenericExtensions).Assembly.GetName().Name}, v{typeof(GenericExtensions).Assembly.GetName().Version}, Namespace: {typeof(GenericExtensions).Namespace}, Class: {nameof(GenericExtensions)}");
        Logger.Instance.Debug($" Executes a function if a given predicate is true");
        Logger.Instance.Debug($" > Signature: ({typeof(T)}) If<{typeof(T)}>(this {typeof(T)}, {typeof(Func<T, bool>)}, {typeof(Func<T, T>)})");
        Logger.Instance.Debug($"   > val: {val}");
        Logger.Instance.Debug($"   > predicate: {predicate}");
        Logger.Instance.Debug($"   > func: {func}");

        var isTrue = predicate(val);
        if (isTrue)
        {
            T result = func(val);
            Logger.Instance.Debug($"  > Output: {result}");

            return result;
        }

        Logger.Instance.Debug($"  > Output: {val}");
        return val;
    }

    /// <summary>
    /// Determines whether a value is present in a specified list of values.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="source">The value to check for presence in the list.</param>
    /// <param name="values">The list of values to check against.</param>
    /// <returns>
    /// <see langword="true"/> if the value is present in the list; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks if the specified value is contained within the provided list of values.
    /// </remarks>
    public static bool In<T>(this T source, params T[] values)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(GenericExtensions).Assembly.GetName().Name}, v{typeof(GenericExtensions).Assembly.GetName().Version}, Namespace: {typeof(GenericExtensions).Namespace}, Class: {nameof(GenericExtensions)}");
        Logger.Instance.Debug($" Determines weather values are into list");
        Logger.Instance.Debug($" > Signature: ({typeof(T)}) In<{typeof(T)}>(this {typeof(T)}, {typeof(Func<T, bool>)}, {typeof(Func<T, T>)})");
        Logger.Instance.Debug($"   > source: {source}");
        Logger.Instance.Debug($"   > values: {values}");

        var result = values.ToList().Contains(source);
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Determines whether a value is present in a specified collection of values.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="source">The value to check for presence in the collection.</param>
    /// <param name="values">The collection of values to check against.</param>
    /// <returns>
    ///<see langword="true"/> if the value is present in the collection; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks if the specified value is contained within the provided collection of values.
    /// </remarks>
    public static bool In<T>(this T source, IEnumerable<T> values) => source.In(values.ToArray());

    /// <summary>
    /// Invokes a specified function with the current value and returns the result.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="x">The input value.</param>
    /// <param name="f">The function to invoke.</param>
    /// <returns>
    /// The result of invoking the specified function with the current value.
    /// </returns>
    /// <remarks>
    /// This method applies a specified function to the current value and returns the result.
    /// </remarks>
    public static TResult Pipe<T, TResult>(this T x, in Func<T, TResult> f) => f(x);
}
