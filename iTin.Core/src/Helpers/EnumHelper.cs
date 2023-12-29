
using System;
using System.Collections.Generic;
using System.Linq;

namespace iTin.Core.Helpers;

/// <summary>
/// Static class than contains methods for manipulating objects of type <see cref="T:System.Enum" />.
/// </summary>
public static class EnumHelper
{
    /// <summary>
    /// Creates an enum value of type <typeparamref name="T"/> based on the specified description attribute value.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="descriptionEnum">The description attribute value to match against.</param>
    /// <returns>
    /// An enum value of type <typeparamref name="T"/> that has a description attribute matching the specified value,
    /// or <see langword="null"/> if the enum type is not valid or no match is found.
    /// </returns>
    /// <remarks>
    /// This method searches for enum values with a description attribute that matches the specified value.<br/>
    /// The comparison is case-insensitive.
    /// </remarks>
    public static Enum CreateEnumTypeFromDescriptionAttribute<T>(string descriptionEnum) where T : struct
    {
        var t = typeof(T);

        if (!t.IsEnum)
        {
            return null;
        }

        return Enum
            .GetValues(t)
            .Cast<Enum>()
            .FirstOrDefault(item => 
                string.Equals(item.GetDescription(), descriptionEnum, StringComparison.InvariantCultureIgnoreCase));
    }

    /// <summary>
    /// Creates an enum value of type <typeparamref name="T"/> based on the specified string representation of the enum value.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="enumValue">The string representation of the enum value.</param>
    /// <returns>
    /// An enum value of type <typeparamref name="T"/> parsed from the specified string representation,
    /// or the default value of <typeparamref name="T"/> if the parsing fails or the enum type is not valid.
    /// </returns>
    /// <remarks>
    /// This method uses <strong>Enum.TryParse</strong> to parse the string representation into an enum value.<br/>
    /// If parsing is successful, the parsed enum value is returned; otherwise, the default value of <typeparamref name="T"/> is returned.
    /// </remarks>
    public static T CreateEnumTypeFromStringValue<T>(string enumValue) where T : struct
    {
        var t = typeof(T);

        if (!t.IsEnum)
        {
            return default;
        }

        var parsed = Enum.TryParse(enumValue, out T result);
        return parsed ? result : default;
    }

    /// <summary>
    /// Creates a list of string values from the description attributes of enum values of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <returns>
    /// A list of string values representing the description attributes of enum values of type <typeparamref name="T"/>,
    /// or <see langword="null"/> if the enum type is not valid.
    /// </returns>
    /// <remarks>
    /// This method retrieves all enum values of type <typeparamref name="T"/> and extracts their description attributes.<br/>
    /// The resulting list contains the description attribute values as strings.
    /// </remarks>
    public static IEnumerable<string> CreateListFromEnumDescriptionAttributes<T>() where T : struct
    {
        var t = typeof(T);

        return !t.IsEnum 
            ? null 
            : Enum.GetValues(t).Cast<Enum>().Select(item => item.GetDescription()).ToList();
    }

    /// <summary>
    /// Creates a list of string values from the names of enum values of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <returns>
    /// A list of string values representing the names of enum values of type <typeparamref name="T"/>,
    /// or <see langword="null"/> if the enum type is not valid.
    /// </returns>
    /// <remarks>
    /// This method retrieves all enum values of type <typeparamref name="T"/> and extracts their names as strings.<br/>
    /// The resulting list contains the names of enum values.
    /// </remarks>
    public static IEnumerable<string> CreateListFromEnumValues<T>() where T : struct => Enum.GetNames(typeof(T)).ToList();

    /// <summary>
    /// Creates a list of integer values from the values of enum values of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <returns>
    /// A list of integer values representing the values of enum values of type <typeparamref name="T"/>,
    /// or an empty list if the enum type is not valid.
    /// </returns>
    /// <remarks>
    /// This method retrieves all enum values of type <typeparamref name="T"/> and extracts their underlying integer values.<br/>
    /// The resulting list contains the integer values of enum values.
    /// </remarks>
    public static IEnumerable<int> CreateListFromEnumValuesValues<T>() => Enum.GetValues(typeof(T)).Cast<int>().ToList();
}
