

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

using System;

#endif

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using iTin.Core.Helpers;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides asynchronous extension methods for working with <see cref="Stream"/> objects.
/// </summary>
public static class StreamExtensionsAsync
{
    /// <summary>
    /// Defines the default buffer size for stream operations.
    /// </summary>
    private const int BufferSize = 81920;


    /// <summary>
    /// Asynchronously converts a <see cref="Stream"/> into a byte array.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result of the task is a byte array containing the content of the original <see cref="Stream"/>.
    /// </returns>
    public static async Task<byte[]> AsByteArrayAsync(this Stream stream, CancellationToken cancellationToken = default) => await AsByteArrayAsync(stream, false, cancellationToken);

    /// <summary>
    /// Asynchronously converts a <see cref="Stream"/> into a byte array.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert.</param>
    /// <param name="closeAfter">A boolean indicating whether to close the stream after conversion.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result of the task is a byte array containing the content of the original <see cref="Stream"/>.
    /// </returns>
    public static async Task<byte[]> AsByteArrayAsync(this Stream stream, bool closeAfter, CancellationToken cancellationToken = default)
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

        var buffer = new byte[stream.Length].AsMemory(..);
        var position = stream.Position;

        _ = await stream.ReadAsync(buffer,cancellationToken);
#else
            var buffer = new byte[stream.Length];
            var position = stream.Position;

            _ = await stream.ReadAsync(buffer, 0, (int)stream.Length, cancellationToken);

#endif

        stream.Seek(position, SeekOrigin.Begin);

        if (closeAfter)
        {
            stream.Close();
        }

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

        Logger.Instance.Debug($"  > Output: {buffer.Length} byte(s) [{buffer[..0]} {buffer[1..1]} {buffer[2..2]} ...]");

        return buffer.ToArray();
#else
            Logger.Instance.Debug($"  > Output: {buffer.Length} byte(s) [{buffer[0]} {buffer[1]} {buffer[2]} ...]");

            return buffer;
#endif
    }

    /// <summary>
    /// Asynchronously converts a <see cref="Stream"/> into a string using the specified encoding.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert.</param>
    /// <param name="encoding">The encoding to use for the conversion. If not provided, UTF-8 encoding is used by default.</param>
    /// <returns>
    /// A task representing the asynchronous operation.<br/>
    /// The result of the task is a string containing the content of the original <see cref="Stream"/>.
    /// </returns>
    public static async Task<string> AsStringAsync(this Stream stream, Encoding encoding = null)
    {
        var safeEncoding = encoding;
        if (encoding == null)
        {
            safeEncoding = Encoding.UTF8;
        }

        stream.Position = 0;
        using var reader = new StreamReader(stream, safeEncoding);
        var result = await reader.ReadToEndAsync();

        return result;
    }

    /// <summary>
    /// Asynchronously creates a new <see cref="Stream"/> that is a copy of the current instance.
    /// </summary>
    /// <param name="stream">The original <see cref="Stream"/> to clone.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the operation to complete.</param>
    /// <returns>
    /// A task representing the asynchronous operation.<br/>
    /// The result of the task is a new <see cref="Stream"/> instance that is a copy of the original stream.
    /// </returns>
    public static async Task<Stream> CloneAsync(this Stream stream, CancellationToken cancellationToken = default)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StreamExtensions).Assembly.GetName().Name}, v{typeof(StreamExtensions).Assembly.GetName().Version}, Namespace: {typeof(StreamExtensions).Namespace}, Class: {nameof(StreamExtensions)}");
        Logger.Instance.Debug(" Create a new object that is a copy of the current instance");
        Logger.Instance.Debug($" > Signature: ({typeof(Stream)}) Clone(this {typeof(Stream)})");

        SentinelHelper.ArgumentNull(stream, nameof(stream));
        Logger.Instance.Debug($"   > stream: {stream.Length} byte(s)");

        MemoryStream ms = new();
        await stream.CopyToAsync(ms, BufferSize, cancellationToken);
        ms.Position = 0;

        Logger.Instance.Debug(" > Output: stream cloned correctly");

        return ms;
    }

    /// <summary>
    /// Asynchronously creates a new collection of <see cref="Stream"/> objects that are copies of the original streams in the current instance.
    /// </summary>
    /// <param name="items">The original collection of <see cref="Stream"/> objects to clone.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the operations to complete.</param>
    /// <returns>
    /// A task representing the asynchronous operation.<br/>
    /// The result of the task is a new collection of <see cref="Stream"/> objects that are copies of the original streams.
    /// </returns>
    public static async Task<IEnumerable<Stream>> CloneAsync(this IEnumerable<Stream> items, CancellationToken cancellationToken = default)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StreamExtensions).Assembly.GetName().Name}, v{typeof(StreamExtensions).Assembly.GetName().Version}, Namespace: {typeof(StreamExtensions).Namespace}, Class: {nameof(StreamExtensions)}");
        Logger.Instance.Debug(" Create a new object that is a copy of the current instance");
        Logger.Instance.Debug($" > Signature: ({typeof(IEnumerable<Stream>)}) Clone(this {typeof(IEnumerable<Stream>)})");

        var streamList = items as IList<Stream> ?? items.ToList();

        SentinelHelper.ArgumentNull(streamList, nameof(items));
        Logger.Instance.Debug($"   > items: {streamList.Count} streams to cloned");

        var clonedList = new List<Stream>();
        foreach (var stream in streamList)
        {
            clonedList.Add(await stream.CloneAsync(cancellationToken));
        }

        Logger.Instance.Debug(" > Output: streams list cloned correctly");

        return clonedList;
    }

    /// <summary>
    /// Asynchronously converts a <see cref="Stream"/> into a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to convert.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the operation to complete.</param>
    /// <returns>
    /// A task representing the asynchronous operation.<br/>
    /// The result of the task is a <see cref="MemoryStream"/> containing the contents of the original stream.
    /// </returns>
    public static async Task<MemoryStream> ToMemoryStreamAsync(this Stream stream, CancellationToken cancellationToken = default)
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

#if NETSTANDARD2_1 || NET5_0_OR_GREATER
            _ = await stream.ReadAsync(tempStream.GetBuffer().AsMemory(..), cancellationToken);
#else
                _ = await stream.ReadAsync(tempStream.GetBuffer(), 0, (int)stream.Length, cancellationToken);
#endif

            await tempStream.FlushAsync(cancellationToken);

            resultStream = tempStream;
            tempStream = null;
        }
        finally
        {

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

            tempStream?.DisposeAsync();

#else

                tempStream?.Dispose();

#endif

        }

        Logger.Instance.Debug($" > Output: {resultStream.Length} byte(s)");

        return resultStream;
    }
}
