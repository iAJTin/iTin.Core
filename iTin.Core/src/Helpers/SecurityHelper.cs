
using System;
using System.Security.Cryptography;
using System.Text;

namespace iTin.Core.Helpers;

/// <summary>
/// Provides security-related utility methods.
/// </summary>
public static class SecurityHelper
{
    /// <summary>
    /// Computes the SHA-1 hash for the input string.
    /// </summary>
    /// <param name="input">The input string to be hashed.</param>
    /// <returns>
    /// A Base64-encoded string representing the SHA-1 hash of the input string.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is <see langword="null"/>.</exception>
    public static string EncryptSha1(string input)
    {
        using var sha1 = SHA1.Create();

        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hash = sha1.ComputeHash(inputBytes);

        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Generates a random password using a GUID.
    /// </summary>
    /// <param name="length">The length of the generated password. Default is 8.</param>
    /// <returns>
    /// A randomly generated password string.
    /// </returns>
    /// <remarks>
    /// The method uses a GUID to generate a unique string and removes hyphens.<br/>
    /// If the specified length is invalid, the entire GUID string is returned.
    /// </remarks>
    public static string GenerateRandomPassword(int length = 8)
    {
        // Get the GUID
        var guidResult = Guid.NewGuid().ToString();

        // Remove the hyphens
        guidResult = guidResult.Replace("-", string.Empty);

        // Make sure length is valid
        if (length <= 0 || length > guidResult.Length)
        {
            return guidResult;
        }

        // Return the first length bytes
#if NETSTANDARD2_1 || NET5_0_OR_GREATER

        return guidResult[..length];

#else

        return guidResult.Substring(0, length);

#endif
    }
}
