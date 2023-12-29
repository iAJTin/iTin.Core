
using System;
using System.IO;
using System.Security;

namespace iTin.Core.Helpers;

/// <summary> 
/// Helper methods for working with streams and files.
/// </summary>
public static class StreamHelper
{
    /// <summary>
    /// Reads the contents of a file and returns them as a byte array.
    /// </summary>
    /// <param name="fileName">The path of the file to read.</param>
    /// <returns>A byte array containing the contents of the file.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="fileName"/> is <see langword="null"/> or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file is denied.</exception>
    /// <exception cref="NotSupportedException">Thrown when the file format is not supported.</exception>
    /// <exception cref="SecurityException">Thrown when the caller does not have the required permission.</exception>
    public static byte[] AsByteArrayFromFile(string fileName)
    {
        SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

        using var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

        return stream.AsByteArray();
    }

    /// <summary>
    /// Reads the contents of a file and returns them as a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="fileName">The path of the file to read.</param>
    /// <returns>A <see cref="MemoryStream"/> containing the contents of the file.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="fileName"/> is <see langword="null"/> or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file is denied.</exception>
    /// <exception cref="NotSupportedException">Thrown when the file format is not supported.</exception>
    /// <exception cref="SecurityException">Thrown when the caller does not have the required permission.</exception>
    public static MemoryStream AsMemoryStreamFromFile(string fileName)
    {
        SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

        MemoryStream ms;
        FileStream fs = null;
        MemoryStream temp = null;

        try
        {
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                temp = new MemoryStream(fs.AsByteArray());
                ms = temp;
                temp = null;
            }
            finally
            {
                temp?.Dispose();
            }
        }
        finally
        {
            fs?.Dispose();
        }

        return ms;
    }

    /// <summary>
    /// Converts the contents of a text file to a <see cref="Stream"/>.
    /// </summary>
    /// <param name="file">The path of the text file to read.</param>
    /// <returns>
    /// A <see cref="Stream"/> containing the contents of the text file.
    /// </returns>
    /// <remarks>
    /// This method reads the contents of a text file and returns them as a <see cref="MemoryStream"/>.
    /// The file path is converted to a string using <see cref="TypeHelper.ToType{T}(object)"/>.
    /// </remarks>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file is denied.</exception>
    /// <exception cref="NotSupportedException">Thrown when the file format is not supported.</exception>
    /// <exception cref="SecurityException">Thrown when the caller does not have the required permission.</exception>
    public static Stream TextFileToStream(string file) => new MemoryStream(File.ReadAllBytes(TypeHelper.ToType<string>(file)));
}
