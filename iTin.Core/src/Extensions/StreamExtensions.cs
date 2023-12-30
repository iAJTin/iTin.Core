
#if NETSTANDARD2_1 || NET5_0_OR_GREATER

using System;

#endif

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using iTin.Core.Helpers;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods related to <see cref="Stream"/> values.
/// </summary> 
public static class StreamExtensions
{
    /// <summary>
    /// Converts the content of a <see cref="Stream"/> to a byte array.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert to a byte array.</param>
    /// <returns>
    /// A byte array containing the content of the <see cref="Stream"/>.
    /// </returns>
    public static byte[] AsByteArray(this Stream stream) => AsByteArray(stream, false);

    /// <summary>
    /// Converts the content of a <see cref="Stream"/> to a byte array.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert to a byte array.</param>
    /// <param name="closeAfter">
    /// A flag indicating whether to close the stream after converting its content to a byte array.
    /// </param>
    /// <returns>
    /// A byte array containing the content of the <see cref="Stream"/>.
    /// </returns>
    public static byte[] AsByteArray(this Stream stream, bool closeAfter)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StreamExtensions).Assembly.GetName().Name}, v{typeof(StreamExtensions).Assembly.GetName().Version}, Namespace: {typeof(StreamExtensions).Namespace}, Class: {nameof(StreamExtensions)}");
        Logger.Instance.Debug(" Returns stream input as byte array");
        Logger.Instance.Debug($" > Signature: ({typeof(byte[])}) AsByteArray(this {typeof(Stream)}, {typeof(bool)})");

        SentinelHelper.ArgumentNull(stream, nameof(stream));
        Logger.Instance.Debug($"   > stream: {stream.Length} byte(s)");
        Logger.Instance.Debug($"   > closeAfter: {closeAfter}");

        stream.Seek(0L, SeekOrigin.Begin);

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

        var buffer = new byte[stream.Length].AsSpan(..);
        var position = stream.Position;

        _ = stream.Read(buffer);
#else
            var buffer = new byte[stream.Length];
            var position = stream.Position;

            _ = stream.Read(buffer, 0, (int)stream.Length);

#endif

        stream.Seek(position, SeekOrigin.Begin);

        if (closeAfter)
        {
            stream.Close();
        }

        Logger.Instance.Debug($"  > Output: {buffer.Length} byte(s) [{buffer[0]} {buffer[1]} {buffer[2]} ...]");

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

        return buffer.ToArray();

#else

            return buffer;
#endif
    }

    /// <summary>
    /// Converts the content of a <see cref="Stream"/> to a string using the specified <see cref="Encoding"/>.<br/>
    /// If no encoding is provided, UTF-8 encoding is used by default.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert to a string.</param>
    /// <param name="encoding">The <see cref="Encoding"/> to use. If not specified, UTF-8 encoding is used.</param>
    /// <returns>
    /// A <see cref="string"/> representation of the content of the <see cref="Stream"/>.
    /// </returns>
    public static string AsString(this Stream stream, Encoding encoding = null)
    {
        var safeEncoding = encoding;
        if (encoding == null)
        {
            safeEncoding = Encoding.UTF8;
        }

        stream.Position = 0;
        using var reader = new StreamReader(stream, safeEncoding);
        var result = reader.ReadToEnd();

        return result;
    }

    /// <summary>
    /// Creates a new <see cref="Stream"/> object that is a copy of the current instance.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to clone.</param>
    /// <returns>
    /// A new <see cref="Stream"/> that is a copy of the current instance.
    /// </returns>
    public static Stream Clone(this Stream stream)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StreamExtensions).Assembly.GetName().Name}, v{typeof(StreamExtensions).Assembly.GetName().Version}, Namespace: {typeof(StreamExtensions).Namespace}, Class: {nameof(StreamExtensions)}");
        Logger.Instance.Debug(" Create a new object that is a copy of the current instance");
        Logger.Instance.Debug($" > Signature: ({typeof(Stream)}) Clone(this {typeof(Stream)})");

        SentinelHelper.ArgumentNull(stream, nameof(stream));
        Logger.Instance.Debug($"   > stream: {stream.Length} byte(s)");

        var ms = new MemoryStream();
        stream.CopyTo(ms);
        ms.Position = 0;

        Logger.Instance.Debug(" > Output: stream cloned correctly");

        return ms;
    }

    /// <summary>
    /// Creates a new collection of <see cref="Stream"/> objects that are copies of the current instances.
    /// </summary>
    /// <param name="items">The collection of <see cref="Stream"/> instances to clone.</param>
    /// <returns>
    /// A new collection of <see cref="Stream"/> objects that are copies of the current instances.
    /// </returns>
    public static IEnumerable<Stream> Clone(this IEnumerable<Stream> items)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StreamExtensions).Assembly.GetName().Name}, v{typeof(StreamExtensions).Assembly.GetName().Version}, Namespace: {typeof(StreamExtensions).Namespace}, Class: {nameof(StreamExtensions)}");
        Logger.Instance.Debug(" Create a new object that is a copy of the current instance");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<Stream>)}) Clone(this {typeof(IEnumerable<Stream>)})");

        var streamList = items as IList<Stream> ?? items.ToList();
        SentinelHelper.ArgumentNull(streamList, nameof(items));
        Logger.Instance.Debug($"   > items: {streamList.Count} streams to cloned");

        var clonedList =  streamList.Select(item => item.Clone());
        Logger.Instance.Debug(" > Output: streams list cloned correctly");

        return clonedList;
    }

    /// <summary>
    /// Converts a <see cref="Stream"/> into a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert.</param>
    /// <returns>
    /// A <see cref="MemoryStream"/> containing the content of the original <see cref="Stream"/>.
    /// </returns>
    public static MemoryStream ToMemoryStream(this Stream stream)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StreamExtensions).Assembly.GetName().Name}, v{typeof(StreamExtensions).Assembly.GetName().Version}, Namespace: {typeof(StreamExtensions).Namespace}, Class: {nameof(StreamExtensions)}");
        Logger.Instance.Debug($" Convert a Stream into {typeof(MemoryStream)}");
        Logger.Instance.Debug($" > Signature: ({typeof(MemoryStream)}) ToMemoryStream(this {typeof(Stream)})");

        SentinelHelper.ArgumentNull(stream, nameof(stream));
        Logger.Instance.Debug($"   > stream: {stream.Length} byte(s)");

        MemoryStream resultStream;
        MemoryStream tempStream = null;

        try
        {
            tempStream = new MemoryStream();
            tempStream.SetLength(stream.Length);

            stream.Seek(0L, SeekOrigin.Begin);

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

            _ = stream.Read(tempStream.GetBuffer().AsSpan(..));

#else

                _ = stream.Read(tempStream.GetBuffer(), 0, (int)stream.Length);

#endif
                
            tempStream.Flush();

            resultStream = tempStream;
            tempStream = null;
        }
        finally
        {
            tempStream?.Dispose();
        }

        Logger.Instance.Debug($" > Output: {resultStream.Length} byte(s)");

        return resultStream;
    }
}
