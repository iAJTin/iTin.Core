
using System;
using System.Collections.ObjectModel;
using System.Linq;

using iTin.Core.Helpers;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with <see cref="ReadOnlyCollection{T}"/> of bytes.
/// </summary>
public static class ReadOnlyCollectionExtensions
{
    /// <summary>
    /// Gets a 32-bit value (double word) from the specified position in the byte collection.
    /// </summary>
    /// <param name="data">The byte collection.</param>
    /// <param name="start">The starting index for the double word.</param>
    /// <returns>
    /// A 32-bit value obtained from the byte collection.
    /// </returns>
    public static int GetDoubleWord(this ReadOnlyCollection<byte> data, byte start)
    {
        SentinelHelper.ArgumentNull(data, nameof(data));
            
        return data[start] | data[start + 1] << 8 | data[start + 2] << 16 | data[start + 3] << 24;
    }

    /// <summary>
    /// Gets a 64-bit value (quadruple word) from the specified position in the byte collection.
    /// </summary>
    /// <param name="data">The byte collection.</param>
    /// <param name="start">The starting index for the quadruple word.</param>
    /// <returns>
    /// A 64-bit value obtained from the byte collection.
    /// </returns>
    public static long GetQuadrupleWord(this ReadOnlyCollection<byte> data, byte start)
    {
        SentinelHelper.ArgumentNull(data, nameof(data));

        return data.GetDoubleWord(start) | data.GetDoubleWord((byte) (start + 4)) << 32;
    }

    /// <summary>
    /// Gets a 16-bit value (word) from the specified position in the byte collection.<br/>
    /// ( { a, b, n, n + 1, ...}, n ) => (n + 1, n)
    /// </summary>
    /// <param name="data">The byte collection.</param>
    /// <param name="start">The starting index for the word.</param>
    /// <returns>
    /// A 16-bit value obtained from the byte collection.
    /// </returns>
    public static int GetWord(this ReadOnlyCollection<byte> data, byte start)
    {
        SentinelHelper.ArgumentNull(data, nameof(data));

        return data[start] | data[start + 1] << 8;
    }

    /// <summary>
    /// Extracts a sub-array of bytes from the specified position in the byte collection.
    /// </summary>
    /// <param name="data">The byte collection.</param>
    /// <param name="start">The starting index for the extraction.</param>
    /// <param name="length">The length of the sub-array to extract.</param>
    /// <returns>
    /// A new ReadOnlyCollection of byte containing the extracted sub-array.
    /// </returns>
    public static ReadOnlyCollection<byte> Extract(this ReadOnlyCollection<byte> data, byte start, byte length)
    {
        var dataArray = data.ToArray();
        var subArray = new byte[length];
        Array.Copy(dataArray, start, subArray, 0x00, length);

        return new ReadOnlyCollection<byte>((byte[])subArray.Clone());
    }
}
