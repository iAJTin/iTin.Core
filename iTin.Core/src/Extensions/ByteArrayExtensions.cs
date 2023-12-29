
#if NETSTANDARD2_1 || NET5_0_OR_GREATER

using System;

#endif

using System.IO;
using System.Text;

using iTin.Core.Helpers;
using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Contains extension methods for byte arrays.
/// </summary>
public static class ByteArrayExtensions
{
    /// <summary>
    /// Retrieves a 64-bit integer (Quadruple Word) from the specified position in the byte array.
    /// </summary>
    /// <param name="data">Target data.</param>
    /// <param name="start">Start byte.</param>
    /// <returns>
    /// A <see cref="long"/> containing the value.
    /// </returns>
    public static long GetQuadrupleWord(this byte[] data, byte start)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ByteArrayExtensions).Assembly.GetName().Name}, v{typeof(ByteArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ByteArrayExtensions).Namespace}, Class: {nameof(ByteArrayExtensions)}");
        Logger.Instance.Debug(" Returns a Quadriple Word from this array of bytes starting in start");
        Logger.Instance.Debug($" > Signature: ({typeof(long)}) GetQuadrupleWord(this {typeof(byte[])}, {typeof(byte)})");

        SentinelHelper.ArgumentNull(data, nameof(data));
        Logger.Instance.Debug($"   > data: {data.Length} byte(s) [{data[0]} {data[1]} {data[2]} ...]");

        SentinelHelper.IsTrue(start + 7 > data.Length);
        Logger.Instance.Debug($"   > start: {start}");

        long result = data.GetDoubleWord(start) | data.GetDoubleWord((byte)(start + 4)) << 32;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Converts the byte array to a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="data">The byte array to convert to a <see cref="MemoryStream"/>.</param>
    /// <returns>
    /// A <see cref="MemoryStream"/> containing the data from the byte array.
    /// </returns>
    public static MemoryStream ToMemoryStream(this byte[] data)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ByteArrayExtensions).Assembly.GetName().Name}, v{typeof(ByteArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ByteArrayExtensions).Namespace}, Class: {nameof(ByteArrayExtensions)}");
        Logger.Instance.Debug(" Returns a {typeof(MemoryStream)} from this byte array");
        Logger.Instance.Debug($" > Signature: ({typeof(MemoryStream)}) ToMemoryStream(this {typeof(byte[])})");

        SentinelHelper.ArgumentNull(data, nameof(data));
        Logger.Instance.Debug($"   > data: {data.Length} byte(s) [{data[0]} {data[1]} {data[2]} ...]");

        var result = new MemoryStream(data);
        Logger.Instance.Debug($" > Output: {result.Length} byte(s)");

        return result;
    }

    /// <summary>
    /// Converts the byte array to a printable string using the specified encoding.
    /// </summary>
    /// <param name="data">The byte array to convert to a printable string.</param>
    /// <param name="encoding">The encoding to use for the conversion. If not specified, the default encoding is used.</param>
    /// <returns>
    /// A printable <see cref="string"/> representation of the byte array.
    /// </returns>
    public static string ToPrintableString(this byte[] data, Encoding encoding = null)
    {
        var safeEncoding = encoding;
        if (encoding == null)
        {
            safeEncoding = Encoding.Default;
        }

        var builder = new StringBuilder();
        var encodedData = safeEncoding.GetString(data);
        foreach (var value in encodedData)
        {
            if (char.IsLetterOrDigit(value) || char.IsSeparator(value) || char.IsPunctuation(value))
            {
                builder.Append(value);
            }
            else
            {
                builder.Append(".");
            }
        }

        return builder.ToString();
    }

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

        /// <summary>
        /// Returns a <b>Double Word</b> from this array of bytes starting in <paramref name="start"/>.
        /// </summary>
        /// <param name="data">Target data.</param>
        /// <param name="start">Start byte.</param>
        /// <returns>
        /// A <see cref="T:System.Int32" /> containing the value.
        /// </returns>
        public static int GetDoubleWord(this byte[] data, byte start)
        {
            Logger.Instance.Debug("");
            Logger.Instance.Debug($" Assembly: {typeof(ByteArrayExtensions).Assembly.GetName().Name}, v{typeof(ByteArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ByteArrayExtensions).Namespace}, Class: {nameof(ByteArrayExtensions)}");
            Logger.Instance.Debug(" Returns a Double Word from this array of bytes starting in start");
            Logger.Instance.Debug($" > Signature: ({typeof(int)}) GetDoubleWord(this {typeof(byte[])}, {typeof(byte)})");

            SentinelHelper.ArgumentNull(data, nameof(data));
            Logger.Instance.Debug($"   > data: {data.Length} byte(s) [{data[0]} {data[1]} {data[2]} ...]");

            SentinelHelper.IsTrue(start + 3 > data.Length);
            Logger.Instance.Debug($"   > start: {start}");

            var span = data.AsSpan();
            var result =
                span.Slice(start, 1).GetPinnableReference() |
                span.Slice(start + 1, 1).GetPinnableReference() << 8 |
                span.Slice(start + 2, 1).GetPinnableReference() << 16 |
                span.Slice(start + 3, 1).GetPinnableReference() << 24;

            Logger.Instance.Debug($" > Output: {result}");

            return result;
        }

        /// <summary>
        /// Returns a <b>Word</b> from this array of bytes starting in <paramref name="start"/>. ( { a, b, n, n + 1, ...}, n ) => (n + 1, n)
        /// </summary>
        /// <param name="data">Target data.</param>
        /// <param name="start">Start byte.</param>
        /// <returns>
        /// A <see cref="T:System.Int32" /> containing the value.
        /// </returns>
        public static int GetWord(this byte[] data, byte start)
        {
            Logger.Instance.Debug("");
            Logger.Instance.Debug($" Assembly: {typeof(ByteArrayExtensions).Assembly.GetName().Name}, v{typeof(ByteArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ByteArrayExtensions).Namespace}, Class: {nameof(ByteArrayExtensions)}");
            Logger.Instance.Debug(" Returns a Word from this array of bytes starting in start");
            Logger.Instance.Debug($" > Signature: ({typeof(int)}) GetWord(this {typeof(byte[])}, {typeof(byte)})");

            SentinelHelper.ArgumentNull(data, nameof(data));
            Logger.Instance.Debug($"   > data: {data.Length} byte(s) [{data[0]} {data[1]} {data[2]} ...]");

            SentinelHelper.IsTrue(start + 1 > data.Length);
            Logger.Instance.Debug($"   > start: {start}");

            var span = data.AsSpan();
            var result =
                span.Slice(start, 1).GetPinnableReference() |
                span.Slice(start + 1, 1).GetPinnableReference() << 8;
            Logger.Instance.Debug($" > Output: {result}");

            return result;
        }

#else

    /// <summary>
    /// Retrieves a 32-bit integer (Double Word) from the specified position in the byte array.
    /// </summary>
    /// <param name="data">The byte array from which to retrieve the Double Word.</param>
    /// <param name="start">The starting index in the byte array.</param>
    /// <returns>
    /// A <see cref="int"/> containing the Double Word value.
    /// </returns>
    public static int GetDoubleWord(this byte[] data, byte start)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ByteArrayExtensions).Assembly.GetName().Name}, v{typeof(ByteArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ByteArrayExtensions).Namespace}, Class: {nameof(ByteArrayExtensions)}");
        Logger.Instance.Debug(" Returns a Double Word from this array of bytes starting in start");
        Logger.Instance.Debug($" > Signature: ({typeof(int)}) GetDoubleWord(this {typeof(byte[])}, {typeof(byte)})");

        SentinelHelper.ArgumentNull(data, nameof(data));
        Logger.Instance.Debug($"   > data: {data.Length} byte(s) [{data[0]} {data[1]} {data[2]} ...]");

        SentinelHelper.IsTrue(start + 3 > data.Length);
        Logger.Instance.Debug($"   > start: {start}");

        int result = data[start] | data[start + 1] << 8 | data[start + 2] << 16 | data[start + 3] << 24;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

    /// <summary>
    /// Retrieves a 16-bit integer (Word) from the specified position in the byte array.
    /// </summary>
    /// <param name="data">The byte array from which to retrieve the Word.</param>
    /// <param name="start">The starting index in the byte array.</param>
    /// <returns>
    /// A <see cref="int"/> containing the Word value.
    /// </returns>
    public static int GetWord(this byte[] data, byte start)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ByteArrayExtensions).Assembly.GetName().Name}, v{typeof(ByteArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ByteArrayExtensions).Namespace}, Class: {nameof(ByteArrayExtensions)}");
        Logger.Instance.Debug(" Returns a Word from this array of bytes starting in start");
        Logger.Instance.Debug($" > Signature: ({typeof(int)}) GetWord(this {typeof(byte[])}, {typeof(byte)})");

        SentinelHelper.ArgumentNull(data, nameof(data));
        Logger.Instance.Debug($"   > data: {data.Length} byte(s) [{data[0]} {data[1]} {data[2]} ...]");

        SentinelHelper.IsTrue(start + 1 > data.Length);
        Logger.Instance.Debug($"   > start: {start}");

        int result = data[start] | data[start + 1] << 8;
        Logger.Instance.Debug($" > Output: {result}");

        return result;
    }

#endif

    /// <summary>
    /// Exchanges adjacent bytes in the byte array to create a new byte array.
    /// </summary>
    /// <param name="data">The byte array whose bytes are to be exchanged.</param>
    /// <returns>
    /// A new byte array with exchanged adjacent bytes.
    /// </returns>
    public static byte[] Swap(this byte[] data)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(ByteArrayExtensions).Assembly.GetName().Name}, v{typeof(ByteArrayExtensions).Assembly.GetName().Version}, Namespace: {typeof(ByteArrayExtensions).Namespace}, Class: {nameof(ByteArrayExtensions)}");
        Logger.Instance.Debug(" Returns an array of bytes by exchanging bytes.");
        Logger.Instance.Debug($" > Signature: ({typeof(byte[])}) GetWord(this {typeof(byte[])})");

        SentinelHelper.ArgumentNull(data, nameof(data));
        Logger.Instance.Debug($"   > data: {data.Length} byte(s) [{data[0]} {data[1]} {data[2]} ...]");

        for (var i = 0; i < data.Length; i += 2)
        {
            (data[i], data[i + 1]) = (data[i + 1], data[i]);
        }

        Logger.Instance.Debug($" > Output: {data.Length} byte(s)");

        return data;
    }
}
