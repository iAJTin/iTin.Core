
using System;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace iTin.Core.Helpers;

/// <summary>
/// Helper class providing asynchronous methods for working with streams and files.
/// </summary>
public static class StreamHelperAsync
{
    /// <summary>
    /// Reads the contents of a file asynchronously and returns them as a byte array.
    /// </summary>
    /// <param name="fileName">The path of the file to read.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation (optional).</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation that returns a byte array containing the contents of the file.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="fileName"/> is <see langword="null"/> or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file is denied.</exception>
    /// <exception cref="NotSupportedException">Thrown when the file format is not supported.</exception>
    /// <exception cref="SecurityException">Thrown when the caller does not have the required permission.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the asynchronous operation is canceled.</exception>
    public static async Task<byte[]> AsByteArrayFromFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

        using var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

        return await stream.AsByteArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Reads the contents of a file asynchronously and returns them as a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="fileName">The path of the file to read.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation (optional).</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation that returns a <see cref="MemoryStream"/> containing the contents of the file.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="fileName"/> is <see langword="null"/> or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file is denied.</exception>
    /// <exception cref="NotSupportedException">Thrown when the file format is not supported.</exception>
    /// <exception cref="SecurityException">Thrown when the caller does not have the required permission.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the asynchronous operation is canceled.</exception>
    public static async Task<MemoryStream> AsMemoryStreamFromFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

        MemoryStream ms;
        FileStream fs = null;
        MemoryStream mstemp = null;

        try
        {
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                mstemp = new MemoryStream(await fs.AsByteArrayAsync(cancellationToken));
                ms = mstemp;
                mstemp = null;
            }
            finally
            {
#if NETSTANDARD2_1 || NET5_0_OR_GREATER

                mstemp?.DisposeAsync();
#else
                    mstemp?.Dispose();
#endif
            }
        }
        finally
        {
#if NETSTANDARD2_1 || NET5_0_OR_GREATER

            fs?.DisposeAsync();
#else
                fs?.Dispose();
#endif
        }

        return ms;
    }

    /// <summary>
    /// Reads the contents of a text file asynchronously and returns them as a <see cref="Stream"/>.
    /// </summary>
    /// <param name="file">The path of the text file to read.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation that returns a <see cref="Stream"/>
    /// containing the contents of the text file.
    /// </returns>
    /// <remarks>
    /// This method reads the contents of a text file and returns them as a <see cref="MemoryStream"/> in
    /// an asynchronous manner. The file path is converted to a string using <see cref="TypeHelper.ToType{T}(object)"/>.
    /// </remarks>
    public static async Task<Stream> TextFileToStreamAsync(string file)
    {
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
        return new MemoryStream(await File.ReadAllBytesAsync(TypeHelper.ToType<string>(file)));
#else
            return await Task.FromResult(new MemoryStream(File.ReadAllBytes(TypeHelper.ToType<string>(file))));
#endif
    }
}
