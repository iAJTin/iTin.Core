
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

using iTin.Logging;

namespace iTin.Core.Helpers;

/// <summary>
/// Provides methods for compressing and decompressing text using GZip compression.
/// </summary>
public static class NativeCompressHelper
{
    /// <summary>
    /// Compresses the specified text using GZip compression.
    /// </summary>
    /// <param name="text">The text to compress.</param>
    /// <returns>
    /// A base64-encoded string representing the compressed data.
    /// </returns>
    /// <remarks>
    /// The <see cref="Compress"/> method compresses the specified <paramref name="text"/> using GZip compression.<br/>
    /// If the input <paramref name="text"/> is an empty string, the method returns the empty string.<br/>
    /// The compressed data is represented as a base64-encoded string, including a header that indicates the original size of the data.
    /// </remarks>
    public static string Compress(string text)
    {
        Logger.Instance.Debug("External Call");
        Logger.Instance.Info("  Compress the specified text");
        Logger.Instance.Info("  > Library: iTin.Core");
        Logger.Instance.Info("  > Class: NativeCompressHelper");
        Logger.Instance.Info("  > Method: Compress(string)");
        Logger.Instance.Info("  > Output: System.String");

        if (text == string.Empty)
        {
            return text;
        }

        var buffer = Encoding.UTF8.GetBytes(text);
        var ms = new MemoryStream();
        using (var zip = new GZipStream(ms, CompressionMode.Compress, true))
        {
            zip.Write(buffer, 0, buffer.Length);
        }

        ms.Position = 0; 

        var compressed = new byte[ms.Length];
        ms.Read(compressed, 0, compressed.Length);

        var gzBuffer = new byte[compressed.Length + 4];
        Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
        Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);

        return Convert.ToBase64String(gzBuffer);
    }

    /// <summary>
    /// Decompresses the specified compressed text using GZip decompression.
    /// </summary>
    /// <param name="compressedText">The base64-encoded string representing the compressed data.</param>
    /// <returns>
    /// The decompressed text.
    /// </returns>
    /// <remarks>
    /// The <see cref="Decompress"/> method decompresses the specified <paramref name="compressedText"/> using GZip decompression.<br/>
    /// If the input <paramref name="compressedText"/> is an empty string, the method returns the empty string.<br/>
    /// The decompressed text is returned as a string.
    /// </remarks>
    public static string Decompress(string compressedText)
    {
        Logger.Instance.Debug("External Call");
        Logger.Instance.Info("  Decompress the specified compressed text");
        Logger.Instance.Info("  > Library: iTin.Core");
        Logger.Instance.Info("  > Class: NativeCompressHelper");
        Logger.Instance.Info("  > Method: Decompress(string)");
        Logger.Instance.Info("  > Output: System.String");

        if (compressedText == string.Empty)
        {
            return compressedText;
        }

        MemoryStream ms = null;

        try
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            byte[] buffer = new byte[msgLength];

            ms = new MemoryStream();
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);
            ms.Position = 0;

            using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
            {
                ms = null;

                zip.Read(buffer, 0, buffer.Length);
            }

            return Encoding.UTF8.GetString(buffer);
        }
        finally
        {
            ms?.Dispose();
        }
    }
}
