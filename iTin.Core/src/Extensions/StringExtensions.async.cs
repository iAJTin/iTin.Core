
using System.IO;
using System.Text;
using System.Threading.Tasks;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides asynchronous extension methods for working with strings.
/// </summary>
public static class StringExtensionsAsync
{
    /// <summary>
    /// Asynchronously converts a <see cref="string"/> into a <see cref="Stream"/>.
    /// </summary>
    /// <param name="target">The input string to convert into a stream.</param>
    /// <param name="encoding">The encoding to use for the conversion. If not provided, the default encoding is used.</param>
    /// <returns>
    /// A <see cref="Task{Stream}"/> representing the asynchronous operation.<br/>
    /// The result of the task is a <see cref="Stream"/> containing the content of the original string.
    /// </returns>
    /// <remarks>
    /// This method creates a new <see cref="MemoryStream"/> and writes the string content into it using the specified encoding.<br/>
    /// The resulting stream is positioned at the beginning to allow further reading.
    /// </remarks>
    public static async Task<Stream> AsStreamAsync(this string target, Encoding encoding = null)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(StringExtensions).Assembly.GetName().Name}, v{typeof(StringExtensions).Assembly.GetName().Version}, Namespace: {typeof(StringExtensions).Namespace}, Class: {nameof(StringExtensions)}");
        Logger.Instance.Debug($" Returns a new {typeof(Stream)} from target {typeof(string)}");
        Logger.Instance.Debug($" > Signature: ({typeof(Task<Stream>)}) AsStreamAsync(this {typeof(string)}, {typeof(Encoding)} = null)");
        Logger.Instance.Debug($"   > target: {target}");
        Logger.Instance.Debug($"   > encoding: {encoding}");

        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, encoding ?? Encoding.Default);
        await writer.WriteAsync(target);
        await writer.FlushAsync();
        stream.Position = 0;

        Logger.Instance.Debug($" > Output: {stream.Length} byte(s)");

        return stream;
    }
}
