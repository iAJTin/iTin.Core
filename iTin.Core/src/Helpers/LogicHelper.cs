
using System;
using System.Globalization;

using iTin.Core.Helpers.Enumerations;

namespace iTin.Core.Helpers;

/// <summary>
/// Utility class providing functions for logic and byte manipulation.
/// </summary>
public static class LogicHelper
{
    #region public static properties

    /// <summary>
    /// Gets a function that combines two bytes into a 16-bit unsigned integer (ushort).<br/>
    /// (a, b) => (b, a).
    /// </summary>
    /// <remarks>
    /// The <see cref="Word"/> property represents a function that takes two bytes, <strong>a</strong> and <strong>b</strong>,
    /// and combines them into a 16-bit unsigned integer (ushort).<br/>
    /// The combination is performed by bitwise OR operation on <strong>a</strong> and the left-shifted bits of <strong>b</strong> by 8 positions.
    /// </remarks>
    public static Func<byte, byte, ushort> Word { get; } = (a, b) => (ushort)(a | b << 8);

    /// <summary>
    /// Gets a function that combines two bytes from a byte array into a 16-bit unsigned integer (ushort).<br/>
    /// { (a, b, n, n + 1,...), n } => (n + 1, n).
    /// </summary>
    /// <remarks>
    /// The <see cref="AWord"/> property represents a function that takes a byte array <strong>a</strong> and an index <strong>b</strong>,
    /// and combines the bytes at the specified index and the next index into a 16-bit unsigned integer (ushort).<br/>
    /// The combination is performed by bitwise OR operation on the byte at the index <strong>b</strong>
    /// and the left-shifted bits of the byte at the next index by 8 positions.
    /// </remarks>
    public static Func<byte[], byte, ushort> AWord { get; } = (a, b) => (ushort)(a[b] | a[b + 1] << 8);

    /// <summary>
    /// Gets a function that combines four bytes from a byte array into a 32-bit unsigned integer (uint).
    /// </summary>
    /// <remarks>
    /// The <see cref="AdWord"/> property represents a function that takes a byte array <strong>a</strong> and an index <strong>b</strong>,
    /// and combines the bytes at the specified index and the next three indices into a 32-bit unsigned integer (uint).
    /// The combination is performed by bitwise OR operations on the bytes at the specified indices,
    /// with the left-shifted bits of each byte by multiples of 8 positions.
    /// </remarks>
    public static Func<byte[], byte, uint> AdWord { get; } = (a, b) => (uint)(a[b] | a[b + 1] << 8 | a[b + 2] << 16 | a[b + 3] << 24);

    /// <summary>
    /// Gets a function that combines eight bytes from a byte array into a 64-bit unsigned integer (ulong).
    /// </summary>
    /// <remarks>
    /// The <see cref="AqWord"/> property represents a function that takes a byte array <strong>a</strong> and an index <strong>b</strong>,
    /// and combines the bytes at the specified index and the next seven indices into a 64-bit unsigned integer (ulong).<br/>
    /// The combination is performed by invoking the <see cref="AdWord"/> function twice, once for the lower 32 bits and once for the upper 32 bits,
    /// and then combining the results using a bitwise OR operation on the upper bits left-shifted by 32 positions.
    /// </remarks>
    public static Func<byte[], byte, ulong> AqWord { get; } = (a, b) => AdWord(a, b) | (ulong)AdWord(a, (byte)(b + 4)) << 32;

    #endregion

    #region public static methods

    /// <summary>
    /// Converts a 64-bit unsigned integer (ulong) into an array of eight 8-bit unsigned integers (bytes).
    /// </summary>
    /// <param name="register">The 64-bit unsigned integer to be converted.</param>
    /// <returns>
    /// An array of eight 8-bit unsigned integers (bytes) representing the individual bytes of the 64-bit unsigned integer.
    /// The order of bytes in the array corresponds to the order of words defined in the <see cref="Words"/> enumeration.
    /// </returns>
    /// <remarks>
    /// The <strong>GetWords</strong> method takes a 64-bit unsigned integer <paramref name="register"/> and converts it into an array of eight 8-bit unsigned integers (bytes).<br/>
    /// Each element of the array represents one of the eight words defined in the <see cref="Words"/> enumeration.<br/>
    /// The order of bytes in the array corresponds to the order of words in the enumeration, with the lower byte of the integer represented by the first element,
    /// and the higher byte represented by the last element.
    /// </remarks>
    public static int[] GetWords(ulong register)
    {
        int[] words = [0, 0, 0, 0, 0, 0, 0, 0];

        words[(int)Words.Word00] = (int)(register & 0xff);
        words[(int)Words.Word01] = (int)(register & 0xff00) >> 8;
        words[(int)Words.Word02] = (int)(register & 0xff0000) >> 16;
        words[(int)Words.Word03] = (int)(register & 0xff000000) >> 24;
        words[(int)Words.Word04] = (int)(register & 0xff00000000) >> 32;
        words[(int)Words.Word05] = (int)(register & 0xff0000000000) >> 40;
        words[(int)Words.Word06] = (int)(register & 0xff000000000000) >> 48;
        words[(int)Words.Word07] = (int)(register & 0xff00000000000000) >> 56;

        return words;
    }

    /// <summary>
    /// Converts a 32-bit signed integer (int) into an array of four 8-bit unsigned integers (bytes).
    /// </summary>
    /// <param name="register">The 32-bit signed integer to be converted.</param>
    /// <returns>
    /// An array of four 8-bit unsigned integers (bytes) representing the individual bytes of the 32-bit signed integer.
    /// The order of bytes in the array corresponds to the order of words defined in the <see cref="Words"/> enumeration.
    /// </returns>
    /// <remarks>
    /// The <strong>GetWords</strong> method with a <paramref name="register"/> parameter of type <see cref="int"/> takes a 32-bit signed integer and converts it into an array of four 8-bit unsigned integers (bytes).<br/>
    /// Each element of the array represents one of the four words defined in the <see cref="Words"/> enumeration.<br/>
    /// The order of bytes in the array corresponds to the order of words in the enumeration, with the lower byte of the integer represented by the first element,
    /// and the higher byte represented by the last element.
    /// </remarks>
    public static int[] GetWords(int register) => GetWords((ulong)register);

    /// <summary>
    /// Gets the value of a specific word within a 64-bit unsigned integer (ulong).
    /// </summary>
    /// <param name="register">The 64-bit unsigned integer containing multiple words.</param>
    /// <param name="word">The specific word to retrieve from the 64-bit unsigned integer.</param>
    /// <returns>
    /// The value of the specified word within the 64-bit unsigned integer.
    /// </returns>
    /// <remarks>
    /// The <strong>GetWord</strong> method extracts the value of a specific word within a 64-bit unsigned integer (ulong).<br/>
    /// The <paramref name="word"/> parameter specifies which word to retrieve, and the method returns the corresponding value.<br/>
    /// The order of words in the 64-bit unsigned integer corresponds to the order defined in the <see cref="Words"/> enumeration.
    /// </remarks>
    public static int GetWord(ulong register, Words word) => GetWords(register)[(int)word];

    /// <summary>
    /// Gets the value of a specific word within a 32-bit signed integer (int).
    /// </summary>
    /// <param name="register">The 32-bit signed integer containing multiple words.</param>
    /// <param name="word">The specific word to retrieve from the 32-bit signed integer.</param>
    /// <returns>
    /// The value of the specified word within the 32-bit signed integer.
    /// </returns>
    /// <remarks>
    /// The <strong>GetWord</strong> method extracts the value of a specific word within a 32-bit signed integer (int).<br/>
    /// The <paramref name="word"/> parameter specifies which word to retrieve, and the method returns the corresponding value.<br/>
    /// The order of words in the 32-bit signed integer corresponds to the order defined in the <see cref="Words"/> enumeration.
    /// </remarks>
    public static int GetWord(int register, Words word) => GetWord((ulong)register, word);

    /// <summary>
    /// Gets the individual bytes from a 64-bit unsigned integer (ulong).
    /// </summary>
    /// <param name="register">The 64-bit unsigned integer to extract bytes from.</param>
    /// <returns>
    /// An array of bytes representing the individual bytes of the specified 64-bit unsigned integer.
    /// </returns>
    /// <remarks>
    /// The <strong>GetBytes</strong> method extracts individual bytes from a 64-bit unsigned integer (ulong).<br/>
    /// The resulting byte array represents the binary representation of the specified 64-bit unsigned integer.<br/>
    /// The order of bytes in the array corresponds to the order defined in the <see cref="Bytes"/> enumeration.
    /// </remarks>
    public static byte[] GetBytes(ulong register)
    {
        byte[] bytes = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        bytes[(int)Bytes.Byte00] = (byte)(register & 0xf);
        bytes[(int)Bytes.Byte01] = (byte)((register & 0xf0) >> 4);
        bytes[(int)Bytes.Byte02] = (byte)((register & 0xf00) >> 8);
        bytes[(int)Bytes.Byte03] = (byte)((register & 0xf000) >> 12);
        bytes[(int)Bytes.Byte04] = (byte)((register & 0xf0000) >> 16);
        bytes[(int)Bytes.Byte05] = (byte)((register & 0xf00000) >> 20);
        bytes[(int)Bytes.Byte06] = (byte)((register & 0xf000000) >> 24);
        bytes[(int)Bytes.Byte07] = (byte)((register & 0xf0000000) >> 28);
        bytes[(int)Bytes.Byte08] = (byte)((register & 0xf00000000) >> 32);
        bytes[(int)Bytes.Byte09] = (byte)((register & 0xf000000000) >> 36);
        bytes[(int)Bytes.Byte10] = (byte)((register & 0xf0000000000) >> 40);
        bytes[(int)Bytes.Byte11] = (byte)((register & 0xf00000000000) >> 44);
        bytes[(int)Bytes.Byte12] = (byte)((register & 0xf000000000000) >> 48);
        bytes[(int)Bytes.Byte13] = (byte)((register & 0xf0000000000000) >> 52);
        bytes[(int)Bytes.Byte14] = (byte)((register & 0xf00000000000000) >> 56);
        bytes[(int)Bytes.Byte15] = (byte)((register & 0xf000000000000000) >> 60);

        return bytes;
    }

    /// <summary>
    /// Gets the individual bytes from a 32-bit signed integer (int).
    /// </summary>
    /// <param name="register">The 32-bit signed integer to extract bytes from.</param>
    /// <returns>
    /// An array of bytes representing the individual bytes of the specified 32-bit signed integer.
    /// </returns>
    /// <remarks>
    /// The <strong>GetBytes</strong> method extracts individual bytes from a 32-bit signed integer (int).<br/>
    /// The resulting byte array represents the binary representation of the specified 32-bit signed integer.<br/>
    /// The order of bytes in the array corresponds to the order defined in the <see cref="Bytes"/> enumeration.
    /// </remarks>
    public static byte[] GetBytes(int register) => GetBytes((ulong)register);

    /// <summary>
    /// Gets a specific byte from a 64-bit unsigned integer (ulong).
    /// </summary>
    /// <param name="register">The 64-bit unsigned integer to extract the byte from.</param>
    /// <param name="onebyte">The specific byte to retrieve, represented by the <see cref="Bytes"/> enumeration.</param>
    /// <returns>
    /// The value of the specified byte from the 64-bit unsigned integer.
    /// </returns>
    /// <remarks>
    /// The <strong>GetByte</strong> method retrieves a specific byte from a 64-bit unsigned integer (ulong).<br/>
    /// The <paramref name="onebyte"/> parameter specifies which byte to retrieve, based on the <see cref="Bytes"/> enumeration.
    /// </remarks>
    public static byte GetByte(ulong register, Bytes onebyte) => GetBytes(register)[(int)onebyte];

    /// <summary>
    /// Gets a specific byte from a 32-bit signed integer (int).
    /// </summary>
    /// <param name="register">The 32-bit signed integer to extract the byte from.</param>
    /// <param name="onebyte">The specific byte to retrieve, represented by the <see cref="Bytes"/> enumeration.</param>
    /// <returns>
    /// The value of the specified byte from the 32-bit signed integer.
    /// </returns>
    /// <remarks>
    /// The <strong>GetByte</strong> method retrieves a specific byte from a 32-bit signed integer (int).<br/>
    /// The <paramref name="onebyte"/> parameter specifies which byte to retrieve, based on the <see cref="Bytes"/> enumeration.
    /// </remarks>
    public static byte GetByte(int register, Bytes onebyte) => GetByte((ulong)register, onebyte);

    /// <summary>
    /// Converts a 32-bit signed integer value to a string representation by interpreting each byte as a character.
    /// </summary>
    /// <param name="value">The 32-bit signed integer value to convert.</param>
    /// <returns>
    /// A string representation of the 32-bit signed integer value, where each byte is interpreted as a character.
    /// </returns>
    /// <remarks>
    /// The <see cref="Word2Str"/> method converts a 32-bit signed integer value to a string representation by interpreting each byte as a character.<br/>
    /// The resulting string consists of four characters, each representing one byte of the input value.
    /// </remarks>
    public static string Word2Str(int value) => string.Format(
        CultureInfo.InvariantCulture,
            "{0}{1}{2}{3}",
            (char)(value & 0xff),
            (char)((value & 0xff00) >> 8),
            (char)((value & 0xff0000) >> 16),
            (char)((value & 0xff000000) >> 24));

    /// <summary>
    /// Converts an 8-bit unsigned integer value to a string representation by interpreting the lower nibble as a character.
    /// </summary>
    /// <param name="value">The 8-bit unsigned integer value to convert.</param>
    /// <returns>
    /// A string representation of the 8-bit unsigned integer value, where the lower nibble is interpreted as a character.
    /// </returns>
    /// <remarks>
    /// The <see cref="Byte2Str"/> method converts an 8-bit unsigned integer value to a string representation by interpreting the lower nibble as a character.
    /// The resulting string consists of a single character, representing the lower nibble of the input value.
    /// </remarks>
    public static string Byte2Str(byte value) => ((char)(value & 0x0f)).ToString();

    /// <summary>
    /// Checks whether a specific bit is set in a 64-bit signed integer value.
    /// </summary>
    /// <param name="register">The 64-bit signed integer value to check.</param>
    /// <param name="bit">The bit to check in the value.</param>
    /// <returns>
    /// <see langword="true"/> if the specified bit is set in the 64-bit signed integer value; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// The <strong>CheckBit</strong> method checks whether a specific bit, identified by the <paramref name="bit"/> parameter, is set in the 64-bit signed integer value specified by <paramref name="register"/>.
    /// </remarks>
    public static bool CheckBit(long register, Bits bit) => BitBit(register, (byte)bit); // ((register & (ulong)bit) == (ulong)bit) ? true : false;

    /// <summary>
    /// Checks whether a specific bit is set in an 8-bit unsigned integer value.
    /// </summary>
    /// <param name="register">The 8-bit unsigned integer value to check.</param>
    /// <param name="bit">The bit to check in the value.</param>
    /// <returns>
    /// <see langword="true"/> if the specified bit is set in the 8-bit unsigned integer value; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// The <strong>CheckBit</strong> method checks whether a specific bit, identified by the <paramref name="bit"/> parameter, is set in the 8-bit unsigned integer value specified by <paramref name="register"/>.
    /// </remarks>
    public static bool CheckBit(byte register, Bits bit) => CheckBit((long)register, bit);

    /// <summary>
    /// Checks whether a specific bit is set in a 32-bit signed integer value.
    /// </summary>
    /// <param name="register">The 32-bit signed integer value to check.</param>
    /// <param name="bit">The bit to check in the value.</param>
    /// <returns>
    /// <see langword="true"/> if the specified bit is set in the 32-bit signed integer value; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// The <strong>CheckBit</strong> method checks whether a specific bit, identified by the <paramref name="bit"/> parameter, is set in the 32-bit signed integer value specified by <paramref name="register"/>.
    /// </remarks>
    public static bool CheckBit(int register, Bits bit) => CheckBit((long)register, bit);

    /// <summary>
    /// Gets the value of a specific bit in a 64-bit unsigned integer value.
    /// </summary>
    /// <param name="register">The 64-bit unsigned integer value from which to retrieve the bit value.</param>
    /// <param name="bit">The bit to retrieve from the value.</param>
    /// <returns>
    /// The value of the specified bit in the 64-bit unsigned integer value. Returns 1 if the bit is set; otherwise, returns 0.
    /// </returns>
    /// <remarks>
    /// The <strong>GetBit</strong> method retrieves the value of a specific bit, identified by the <paramref name="bit"/> parameter, from the 64-bit unsigned integer value specified by <paramref name="register"/>.
    /// </remarks>
    public static int GetBit(ulong register, Bits bit) => ((register & (ulong)bit) == (ulong)bit) ? 1 : 0;

    /// <summary>
    /// Gets the value of a specific bit in a 32-bit signed integer value.
    /// </summary>
    /// <param name="register">The 32-bit signed integer value from which to retrieve the bit value.</param>
    /// <param name="bit">The bit to retrieve from the value.</param>
    /// <returns>
    /// The value of the specified bit in the 32-bit signed integer value. Returns 1 if the bit is set; otherwise, returns 0.
    /// </returns>
    /// <remarks>
    /// The <strong>GetBit</strong> method retrieves the value of a specific bit, identified by the <paramref name="bit"/> parameter, from the 32-bit signed integer value specified by <paramref name="register"/>.
    /// </remarks>
    public static int GetBit(int register, Bits bit) => GetBit((ulong)register, bit);

    #endregion

    #region private static methods

    private static readonly Func<long, int, bool> BitBit = (a, b) => (a & (1 << b)) == 1 << b;

    #endregion
}
