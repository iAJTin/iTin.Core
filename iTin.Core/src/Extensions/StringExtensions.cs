
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

using iTin.Core.ComponentModel.Enumerators;

#endif

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with <see cref="string"/> values.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Tries to convert the specified string value to its <see cref="bool"/> equivalent.
    /// Default value is <see langword="false"/>.<br/>
    /// Supported values are: 'true', 'false', 'yes', 'no', 't', 'f', 'y', 'n', '1', '0'.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>
    /// <see langword="true"/> if the conversion is successful; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method performs a case-insensitive comparison of the input string value with various boolean representations.<br/>
    /// If the input value is <see langword="null"/> or empty, the default value is <see langword="false"/>.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when the input value is not a recognized boolean representation.</exception>
    public static bool AsBoolean(this string value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Tries to convert the value specified in its {typeof(bool)} equivalent value. Default value is False. Supported values are: 'true', 'false', 'yes', 'no', 't', 'f', 'y', 'n', '1', '0'");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) AsBoolean(this {typeof(string)})");
        Logger.Instance.Debug($"   > value: {value}");

        if (!value.HasValue())
        {
            Logger.Instance.Debug("  > Output: False");
            return false;
        }

        string val = value.ToLowerInvariant().Trim();
        switch (val)
        {
            case "true":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "false":
                Logger.Instance.Debug("  > Output: False");
                return false;

            case "on":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "off":
                Logger.Instance.Debug("  > Output: False");
                return false;

            case "yes":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "si":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "no":
                Logger.Instance.Debug("  > Output: False");
                return false;

            case "t":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "f":
                Logger.Instance.Debug("  > Output: False");
                return false;

            case "y":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "n":
                Logger.Instance.Debug("  > Output: False");
                return false;

            case "1":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "0":
                Logger.Instance.Debug("  > Output: False");
                return false;
        }

        var ex = new ArgumentException("Value is not a boolean value.");
        Logger.Instance.Error("Value is not a boolean value", ex);
        throw ex;
    }

    /// <summary>
    /// Returns a new <see cref="Stream"/> from the specified string target.
    /// </summary>
    /// <param name="target">The string value to convert into a stream.</param>
    /// <param name="encoding">The encoding to use for the stream. If not provided, the default encoding is used.</param>
    /// <returns>
    /// A <see cref="Stream"/> containing the content of the input string.
    /// </returns>
    /// <remarks>
    /// This method creates a new <see cref="MemoryStream"/> and writes the string content using the specified or default encoding.<br/>
    /// The resulting stream is positioned at the beginning.
    /// </remarks>
    public static Stream AsStream(this string target, Encoding encoding = null)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Returns a new {typeof(Stream)} from target {typeof(string)}");
        Logger.Instance.Debug($" > Signature: ({typeof(Stream)}) AsStream(this {typeof(string)}, {typeof(Encoding)} = null)");
        Logger.Instance.Debug($"   > target: {target}");
        Logger.Instance.Debug($"   > encoding: {encoding}");

        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, encoding ?? Encoding.Default);
        writer.WriteAsync(target);
        writer.Flush();
        stream.Position = 0;

        Logger.Instance.Debug($" > Output: {stream.Length} byte(s)");

        return stream;
    }

    /// <summary>
    /// Decodes the input string in base64 using the specified encoding.<br/>
    /// If encoding is not specified, UTF-8 encoding is used by default.
    /// </summary>
    /// <param name="value">The base64-encoded string to decode.</param>
    /// <param name="encoding">The encoding to use for the decoding. If not provided, UTF-8 encoding is used.</param>
    /// <returns>
    /// The decoded string from the base64 input using the specified or default encoding.
    /// </returns>
    /// <remarks>
    /// This method decodes a base64-encoded string into its original representation using the specified or default encoding.
    /// </remarks>
    public static string FromBase64(this string value, Encoding encoding = null)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Decodes the input {typeof(string)} in base64 using specified encoding, if not specified by default the UTF8 encoding is used");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) FromBase64(this {typeof(string)}, {typeof(Encoding)} = null)");
        Logger.Instance.Debug($"   > value: {value}");
        Logger.Instance.Debug($"   > encoding: {encoding}");

        Encoding safeEncoding = encoding;
        if (encoding == null)
        {
            safeEncoding = Encoding.UTF8;
            Logger.Instance.Debug($"               Used default value UTF8");
        }

        byte[] bytes = Convert.FromBase64String(value);
        string result = safeEncoding.GetString(bytes);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Determines whether the specified string has a value.
    /// </summary>
    /// <param name="value">The string to check for a value.</param>
    /// <returns>
    /// <see langword="true"/> if the string is not <see langword="null"/> or empty; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks whether the specified string has a value by verifying that it is not <see langword="null"/> or empty.
    /// </remarks>
    public static bool HasValue(this string value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Determines whether this value has a value");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) HasValue(this {typeof(string)}");
        Logger.Instance.Debug($"   > value: {value}");

        var hasValue = !string.IsNullOrEmpty(value);
        Logger.Instance.Debug($"  > Output: {hasValue}");

        return hasValue;
    }

    /// <summary>
    /// Determines whether the specified string represents a boolean value.
    /// </summary>
    /// <param name="value">The string to check for a boolean value.</param>
    /// <returns>
    /// <see langword="true"/> if the string represents a boolean value; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks whether the specified string represents a boolean value by comparing it to common boolean representations,
    /// such as 'true', 'false', 'yes', 'no', 't', 'f', 'y', 'n', 'on', 'off', '1', and '0'.
    /// </remarks>
    public static bool IsBoolean(this string value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Determines whether this value is a {typeof(bool)} value");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsBoolean(this {typeof(string)})");
        Logger.Instance.Debug($"   > value: {value}");

        if (!value.HasValue())
        {
            Logger.Instance.Debug("  > Output: False");
            return false;
        }

        string val = value.ToLowerInvariant().Trim();
        switch (val)
        {
            case "true":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "false":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "on":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "off":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "si":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "yes":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "no":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "t":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "f":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "y":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "n":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "1":
                Logger.Instance.Debug("  > Output: True");
                return true;

            case "0":
                Logger.Instance.Debug("  > Output: True");
                return true;
        }

        Logger.Instance.Debug("  > Output: False");
        return false;
    }

    /// <summary>
    /// Determines whether the current instance and another specified string object have the same value, ignoring case.
    /// </summary>
    /// <param name="instance">The string to compare.</param>
    /// <param name="comparing">The string to compare to the current instance.</param>
    /// <returns>
    /// <see langword="true"/> if the strings have the same value, ignoring case; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method performs a case-insensitive comparison to determine whether the current instance and the specified string have the same value.<br/>
    /// It returns <see langword="true"/> if the values are equal, ignoring case; otherwise, it returns <see langword="false"/>.
    /// </remarks>
    public static bool IsCaseInsensitiveEqual(this string instance, string comparing)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Determines whether this instance and another specified {typeof(string)} object have the same value");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) HasValue(this {typeof(string)}");
        Logger.Instance.Debug($"   > instance: {instance}");
        Logger.Instance.Debug($"   > comparing: {comparing}");

        var result = string.Compare(instance, comparing, StringComparison.OrdinalIgnoreCase) == 0;
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Determines whether the current instance and another specified string object have the same value, considering case sensitivity.
    /// </summary>
    /// <param name="instance">The string to compare.</param>
    /// <param name="comparing">The string to compare to the current instance.</param>
    /// <returns>
    /// <see langword="true"/> if the strings have the same value, considering case sensitivity; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method performs a case-sensitive comparison to determine whether the current instance and the specified string have the same value.<br/>
    /// It returns <see langword="true"/> if the values are equal, considering case sensitivity; otherwise, it returns <see langword="false"/>.
    /// </remarks>
    public static bool IsCaseSensitiveEqual(this string instance, string comparing)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Determines whether this instance and another specified {typeof(string)} object have the same value");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) HasValue(this {typeof(string)}");
        Logger.Instance.Debug($"   > instance: {instance}");
        Logger.Instance.Debug($"   > comparing: {comparing}");

        var result = string.CompareOrdinal(instance, comparing) == 0;
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Determines whether the specified string value is a <see langword="null"/> value.
    /// </summary>
    /// <param name="value">The string value to check for <see langword="null"/>.</param>
    /// <returns>
    /// <see langword="true"/> if the specified string value is <see langword="null"/>; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks whether the specified string value is a <see langword="null"/> value.<br/>
    /// It returns <see langword="true"/> if the value is <see langword="null"/>; otherwise, it returns <see langword="false"/>.
    /// </remarks>
    public static bool IsNullValue(this string value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Determines whether {typeof(string)} value is null (Nothing in Visual Basic) value.");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsNullValue(this {typeof(string)}");
        Logger.Instance.Debug($"   > value: {value}");

        var result = value == null;
        Logger.Instance.Debug($"  > Output: {result}");

        return result;
    }

    /// <summary>
    /// Determines whether the specified string value is a numeric value.
    /// </summary>
    /// <param name="value">The string value to check for numeric content.</param>
    /// <returns>
    /// <see langword="true"/> if the specified string value represents a numeric value; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks whether the specified string value is a numeric value by attempting to parse it as a long integer.<br/>
    /// It returns <see langword="true"/> if the parsing is successful; otherwise, it returns <see langword="false"/>.
    /// </remarks>
    public static bool IsNumeric(this string value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug(" Determines whether the specified value is a numeric value");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) IsNumeric(this {typeof(string)})");
        Logger.Instance.Debug($"   > value: {value}");

        bool result = long.TryParse(value, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out _);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Returns a string containing a specified number of characters from the left side of a string.
    /// </summary>
    /// <param name="str">Expression of type <see cref="string"/> from which the characters that are furthest to the left are returned.</param>
    /// <param name="length">Numeric expression of type <see cref= "int"/> that indicates how many characters are to be returned.</param>
    /// <returns>
    /// A <see cref="string"/> with the result.
    /// </returns>
    public static string Left(this string str, int length)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Returns a string containing a specified number of characters from the left side of a {typeof(string)}");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) Left(this {typeof(string)}, {typeof(int)})");
        Logger.Instance.Debug($"   > str: {str}");
        Logger.Instance.Debug($"   > length: {length}");

        var result = string.IsNullOrEmpty(str) ? str : str.Substring(0, length);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Returns a string that contains a specified number of characters from the specified position.
    /// </summary>
    /// <param name="str">Name of the variable <see cref="T:System.String" /> to be modified.</param>
    /// <param name="start">Position of the character where the extraction starts</param>
    /// <param name="length">Number of characters to be extracted.</param>
    /// <returns>
    /// A <see cref="T:System.String" /> with the result.
    /// </returns>
    public static string Mid(this string str, int start, int length)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Returns a string containing a specified number of characters from the right side of a {typeof(string)}");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) Mid(this {typeof(string)}, {typeof(int)}, {typeof(int)})");
        Logger.Instance.Debug($"   > str: {str}");
        Logger.Instance.Debug($"   > start: {start}");
        Logger.Instance.Debug($"   > length: {length}");

        string result = string.IsNullOrEmpty(str) ? str : str.Substring(start, length);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Removes control characters from the specified string.
    /// </summary>
    /// <param name="input">The string from which control characters should be removed.</param>
    /// <returns>
    /// A new string that is equivalent to the input string, but with control characters removed.
    /// </returns>
    /// <remarks>
    /// Control characters are characters with ASCII values less than 32, excluding '\r' (carriage return),
    /// '\n' (newline), and '\t' (tab).
    /// </remarks>
    public static string RemoveControlCharacters(this string input) => new(input.Where(c => !char.IsControl(c)).ToArray());

    /// <summary>
    /// Reverses the characters in the specified string.
    /// </summary>
    /// <param name="value">The string to reverse.</param>
    /// <returns>
    /// A new string that contains the characters of the input string in reverse order.
    /// </returns>
    public static string Reverse(this string value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Returns a {typeof(string)} that contains the value of value parameter reversed");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) Reverse(this {typeof(string)})");
        Logger.Instance.Debug($"   > value: {value}");

        var charArray = value.ToCharArray();
        Array.Reverse(charArray);

        var result = new string(charArray);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Returns a string that contains a specified number of characters from the right side of a string.
    /// </summary>
    /// <param name="str">Expression of type <see cref = "T:System.String" /> from which the characters that are furthest to the right are returned.</param>
    /// <param name="length">Numeric expression of type <see cref= "T:System.Int32" /> that indicates how many characters are to be returned.</param>
    /// <returns>
    /// A <see cref="T:System.String" /> with the result.
    /// </returns>
    public static string Right(this string str, int length)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Returns a string containing a specified number of characters from the right side of a {typeof(string)}");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) Right(this {typeof(string)}, {typeof(int)})");
        Logger.Instance.Debug($"   > str: {str}");
        Logger.Instance.Debug($"   > length: {length}");

        string result = string.IsNullOrEmpty(str) ? str : str.Substring(str.Length - length, length);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Encodes the input string in Base64 using the specified encoding; if not specified, the default is UTF-8.
    /// </summary>
    /// <param name="value">The string to encode.</param>
    /// <param name="encoding">The encoding to use for the conversion. If not provided, UTF-8 encoding is used by default.</param>
    /// <returns>
    /// A Base64-encoded string representing the input string.
    /// </returns>
    public static string ToBase64(this string value, Encoding encoding = null)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Encodes the input {typeof(string)} in base64 using specified encoding, if not specified by default the UTF8 encoding is used");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToBase64(this {typeof(string)}, {typeof(Encoding)} = null)");
        Logger.Instance.Debug($"   > value: {value}");
        Logger.Instance.Debug($"   > encoding: {encoding}");

        Encoding safeEncoding = encoding;
        if (encoding == null)
        {
            safeEncoding = Encoding.UTF8;
            Logger.Instance.Debug($"               Used default value UTF8");
        }

        byte[] bytes = safeEncoding.GetBytes(value);
        string result = Convert.ToBase64String(bytes);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts the string to a byte array using the specified encoding; if not specified, the default is UTF-8.
    /// </summary>
    /// <param name="value">The string to convert to a byte array.</param>
    /// <param name="encoding">The encoding to use for the conversion. If not provided, UTF-8 encoding is used by default.</param>
    /// <returns>
    /// A byte array representing the content of the input string.
    /// </returns>
    /// <remarks>
    /// If the input string is empty or <see langword="null"/>, the method returns <see langword="null"/>.
    /// </remarks>
    public static byte[] ToByteArray(this string value, Encoding encoding = null)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Converts string to {typeof(byte[])}");
        Logger.Instance.Debug($" > Signature: ({typeof(byte[])}) ToByteArray(this {typeof(string)}, {typeof(Encoding)}=null)");
        Logger.Instance.Debug($"   > value: {value}");
        Logger.Instance.Debug($"   > encoding: {encoding}");

        if (!value.HasValue())
        {
            Logger.Instance.Debug($"  > Output: null");
            return null;
        }

        try
        {
            byte[] result = value.AsStream(encoding).AsByteArray();
            Logger.Instance.Debug($"  > Output: {result}");
            return result;
        }
        catch (ArgumentException)
        {
            Logger.Instance.Debug($"  > Output: null");
            return null;
        }
    }

    /// <summary>
    /// Returns a string that contains the input string in camel case format.
    /// </summary>
    /// <param name="instance">The string to convert to camel case.</param>
    /// <returns>
    /// A string in camel case format.
    /// </returns>
    public static string ToCamelCase(this string instance)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Returns a string that contains input string as camel case format");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) ToCamelCase(this {typeof(string)})");
        Logger.Instance.Debug($"   > instance: {instance}");

        var result = instance[0].ToString().ToLowerInvariant() + instance.Substring(1);
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts a string to an enumeration value of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The enumeration type to convert to.</typeparam>
    /// <param name="value">The string to convert to an enumeration value.</param>
    /// <param name="defaultValue">The default value to return if the conversion fails. Default is <c>default(T)</c>.</param>
    /// <returns>
    /// An enumeration value of type <typeparamref name="T"/> if the conversion is successful; otherwise, the default value.
    /// </returns>
    public static T ToEnum<T>(this string value, T defaultValue = default) where T : struct
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Converts string to {typeof(Enum)} object");
        Logger.Instance.Debug($" > Signature: ({typeof(T)}) ToEnum(this {typeof(string)}, {typeof(T)}=default(T))");
        Logger.Instance.Debug($"   > value: {value}");

        if (!value.HasValue())
        {
            Logger.Instance.Debug($"  > Output: {defaultValue}");
            return defaultValue;
        }

        try
        {
            T result = (T)Enum.Parse(typeof(T), value, true);
            Logger.Instance.Debug($"  > Output: {result}");
            return result;
        }
        catch (ArgumentException)
        {
            Logger.Instance.Debug($"  > Output: {defaultValue}");
            return defaultValue;
        }
    }

    /// <summary>
    /// Converts a string to an enumeration value of type <typeparamref name="T"/> based on the description attribute of the enum.
    /// </summary>
    /// <typeparam name="T">The enumeration type to convert to.</typeparam>
    /// <param name="description">The description attribute value to match with an enum value.</param>
    /// <returns>
    /// An enumeration value of type <typeparamref name="T"/> that has a description attribute matching the provided value.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown if no enum value with the specified description is found.</exception>
    public static T ToEnumByDescription<T>(this string description) where T : struct
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Converts string to enum object by description attribute");
        Logger.Instance.Debug($" > Signature: ({typeof(T)}) ToEnumByDescription<T>(this {typeof(string)})");
        Logger.Instance.Debug($"   > description: {description}");

        T result = default;
        var items = Enum.GetValues(typeof(T));
        foreach (Enum item in items)
        {
            if (item.GetDescription() != description)
            {
                continue;
            }

            result = (T)Enum.Parse(typeof(T), item.ToString(), true);
            break;
        }

        Logger.Instance.Debug($"  > Output: {result}");
        return result;
    }

    /// <summary>
    /// Splits a string into a list of substrings based on the specified separator character.
    /// </summary>
    /// <param name="value">The string to split.</param>
    /// <param name="separator">The character used to split the string.</param>
    /// <returns>
    /// An enumerable collection of substrings.
    /// </returns>
    public static IEnumerable<string> ToListWithSeparator(this string value, char separator) => value.ToListWithSeparator([separator]);

    /// <summary>
    /// Returns a new list of strings by splitting the input string using the specified characters as separators.
    /// </summary>
    /// <param name="value">The input string to be split.</param>
    /// <param name="separators">An array of characters used as separators for splitting the input string.</param>
    /// <returns>
    /// A list of strings resulting from splitting the input string using the specified separators.
    /// The returned list excludes empty entries resulting from consecutive separators or leading/trailing separators.
    /// </returns>
    /// <remarks>
    /// This method splits the input string using the specified characters as separators.<br/>
    /// Empty entries resulting from consecutive separators or leading/trailing separators are excluded from the final list.
    /// </remarks>
    public static IEnumerable<string> ToListWithSeparator(this string value, char[] separators)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug(" Returns a new list of strings split with specified chars");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<string>)}) ToListWithSeparator(this {typeof(string)}, {typeof(char[])})");
        Logger.Instance.Debug($"   > value: {value}");
        Logger.Instance.Debug($"   > separators: {separators.Length}, [{separators[0]} ...]");

        var result = value.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
        Logger.Instance.Debug($" > Output: {result.Count} elements, [{result[0]} ...]");

        return result;
    }

    /// <summary>
    /// Converts a <see cref="string"/> into a <see cref="SecureString"/> object.
    /// </summary>
    /// <param name="text">The input string to be converted.</param>
    /// <returns>
    /// A <see cref="SecureString"/> containing the characters from the input string.
    /// </returns>
    /// <remarks>
    /// This method creates a new <see cref="SecureString"/> and appends each character from the input string.<br/>
    /// The resulting <see cref="SecureString"/> provides a more secure representation of the original string.
    /// </remarks>
    public static SecureString ToSecureString(this string text)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Converts {typeof(string)} into {typeof(SecureString)} object");
        Logger.Instance.Debug($" > Signature: ({typeof(SecureString)}) ToSecureString(this {typeof(string)})");
        Logger.Instance.Debug($"   > text: {text}");

        var secureString = new SecureString();
        foreach (var c in text)
        {
            secureString.AppendChar(c);
        }

        Logger.Instance.Debug(" > Output:");
        Logger.Instance.Debug("   > Value: ******* (Secured)");
        Logger.Instance.Debug($"   > Lenght: {text.Length} (bytes)");

        return secureString;
    }

    /// <summary>
    /// Converts the first letter of a <see cref="string"/> to uppercase.
    /// </summary>
    /// <param name="value">The input string to be modified.</param>
    /// <returns>
    /// A new <see cref="string"/> with the first letter in uppercase.<br/>
    /// If the input string is empty, the method returns the original string.
    /// </returns>
    /// <remarks>
    /// This method takes a string as input and returns a new string where the first letter is converted to uppercase.
    /// </remarks>
    public static string UpperCaseFirstLetter(this string value)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug(" Uppers the case first letter.");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) UpperCaseFirstLetter(this {typeof(string)})");
        Logger.Instance.Debug($"   > value: {value}");

        if (value.Length <= 0)
        {
            Logger.Instance.Debug($" > Output: {value}");
            return value;
        }

        var array = value.ToCharArray();
        array[0] = char.ToUpper(array[0]);

        Logger.Instance.Debug($" > Output: {array[0]}");

        return new string(array);
    }

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

    /// <summary>
    /// Provides a way to efficiently enumerate substrings of a <see cref="string"/> based on an array of separators.
    /// </summary>
    /// <param name="str">The input string to be split.</param>
    /// <param name="separators">An array of characters that act as separators for splitting the string.</param>
    /// <returns>
    /// A <see cref="SplitEnumerator"/> that can be used to efficiently iterate over the substrings of the input string.
    /// </returns>
    /// <remarks>
    /// This method creates a <see cref="SplitEnumerator"/> that allows iterating over substrings of the input string based on the provided array of separators.<br/>
    /// It is more memory-efficient than creating an array of substrings upfront.
    /// </remarks>
    public static SplitEnumerator SplitString(this string str, char[] separators) => new(str.AsSpan(), separators.AsSpan());

    /// <summary>
    /// Provides a way to efficiently enumerate lines of a <see cref="string"/>.
    /// </summary>
    /// <param name="str">The input string to be split into lines.</param>
    /// <returns>
    /// A <see cref="SplitEnumerator"/> that can be used to efficiently iterate over the lines of the input string.
    /// </returns>
    /// <remarks>
    /// This method creates a <see cref="SplitEnumerator"/> that allows iterating over lines of the input string.<br/>
    /// It considers both carriage return ('\r') and line feed ('\n') characters as line separators.<br/>
    /// It is more memory-efficient than creating an array of lines upfront.
    /// </remarks>
    public static SplitEnumerator SplitLines(this string str) => new(str, new[] {'\r', '\n'});

#else

    /// <summary>
    /// Splits a <see cref="string"/> into an array of lines.
    /// </summary>
    /// <param name="str">The input string to be split into lines.</param>
    /// <returns>
    /// An array of lines extracted from the input string.
    /// </returns>
    /// <remarks>
    /// This method splits the input string into lines using both carriage return ('\r') and line feed ('\n') characters as line separators.<br/>
    /// Empty lines are excluded from the result.
    /// </remarks>
    public static string[] SplitLines(this string str) => str.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

#endif
}
