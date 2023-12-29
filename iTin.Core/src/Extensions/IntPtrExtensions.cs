
using System;
using System.Runtime.InteropServices;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with <see cref="IntPtr"/>.
/// </summary>
public static class IntPtrExtensions
{
    /// <summary>
    /// Converts a block of memory, starting from the specified index, into a byte array.
    /// </summary>
    /// <param name="source">The starting address of the memory block.</param>
    /// <param name="startIndex">The index in the memory block from where the conversion starts.</param>
    /// <param name="length">The number of bytes to convert into a byte array.</param>
    /// <returns>
    /// A byte array containing the converted memory block.
    /// </returns>
    /// <remarks>
    /// This method copies a specified number of bytes from the memory block starting at the specified index into a newly allocated byte array.<br/>
    /// It then frees the allocated memory block.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when <paramref name="startIndex"/> or <paramref name="length"/> is less than zero.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is an IntPtr.Zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="startIndex"/> is greater than the size of the allocated memory block.</exception>
    public static byte[] ToByteArray(this IntPtr source, int startIndex, int length)
    {
        var byteArray = new byte[length];
        Marshal.Copy(source, byteArray, startIndex, length);
        Marshal.FreeHGlobal(source);

        return byteArray;
    }
}
