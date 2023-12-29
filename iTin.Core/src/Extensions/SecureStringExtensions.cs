
using System;
using System.Runtime.InteropServices;
using System.Security;

using iTin.Logging;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for working with <see cref="SecureString"/> objects.
/// </summary>
public static class SecureStringExtensions
{
    /// <summary>
    /// Determines whether the input <see cref="SecureString"/> is disposed.
    /// </summary>
    /// <param name="target">The <see cref="SecureString"/> to check for disposal.</param>
    /// <returns>
    /// <see langword="true"/> if the <see cref="SecureString"/> is disposed; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool Disposed(this SecureString target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(SecureStringExtensions).Assembly.GetName().Name}, v{typeof(SecureStringExtensions).Assembly.GetName().Version}, Namespace: {typeof(SecureStringExtensions).Namespace}, Class: {nameof(SecureStringExtensions)}");
        Logger.Instance.Debug(" Determines whether input secure string is disposed");
        Logger.Instance.Debug($" > Signature: ({typeof(bool)}) Disposed(this {typeof(SecureString)})");
        Logger.Instance.Debug($"   > target: {target}");

        bool disposed = false;

        try
        {
            var test = target.Length;
        }
        catch (ObjectDisposedException)
        {
            disposed = true;
        }

        Logger.Instance.Debug($" > Output: {disposed}");

        return disposed;
    }

    /// <summary>
    /// Returns the value stored in the specified <see cref="SecureString"/>.
    /// </summary>
    /// <param name="target">The <see cref="SecureString"/> from which to retrieve the value.</param>
    /// <returns>
    /// The decrypted string value stored in the <see cref="SecureString"/>.<b/>
    /// Returns <see langword="null"/> if the <see cref="SecureString"/> is disposed.
    /// </returns>
    public static string Value(this SecureString target)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug($" Assembly: {typeof(SecureStringExtensions).Assembly.GetName().Name}, v{typeof(SecureStringExtensions).Assembly.GetName().Version}, Namespace: {typeof(SecureStringExtensions).Namespace}, Class: {nameof(SecureStringExtensions)}");
        Logger.Instance.Debug(" Returns the value stored in the specified secure string");
        Logger.Instance.Debug($" > Signature: ({typeof(string)}) Value(this {typeof(SecureString)})");
        Logger.Instance.Debug($"   > target: {target}");

        bool disposed = target.Disposed();
        if (disposed)
        {
            return null;
        }

        IntPtr pointerToTarget = Marshal.SecureStringToBSTR(target);
        string text = Marshal.PtrToStringBSTR(pointerToTarget);
        Marshal.FreeBSTR(pointerToTarget);

        Logger.Instance.Debug($" > Output: {text}");

        return text;
    }
}
