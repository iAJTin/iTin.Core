
using System;
using System.Net;
using System.Threading.Tasks;

using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;

namespace iTin.Core;

/// <summary>
/// Provides extension methods for checking the accessibility of a <see cref="Uri"/>.
/// </summary> 
public static class UriExtensions
{
    /// <summary>
    /// Checks whether the specified <see cref="Uri"/> is accessible.
    /// </summary>
    /// <param name="uri">The <see cref="Uri"/> to check for accessibility.</param>
    /// <returns>
    /// A <see cref="IResult"/> indicating the accessibility status.<br/>
    /// If the <see cref="Uri"/> is accessible, the result is a success; otherwise, it contains an error message.
    /// </returns>
    /// <remarks>
    /// This method attempts to create a <see cref="WebRequest"/> using the specified <see cref="Uri"/> and checks whether a response can be obtained.<br/>
    /// If successful, the result is a success; otherwise, it contains an error message.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input <see cref="Uri"/> (<paramref name="uri"/>) is <see langword="null"/>.</exception>
    public static IResult IsAccessible(this Uri uri)
    {
        if (uri == null)
        {
            return BooleanResult.CreateErrorResult("url can not be null");
        }

        try
        {
            var request = WebRequest.Create(uri);
            _ = request.GetResponse();

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the specified <see cref="Uri"/> is accessible asynchronously.
    /// </summary>
    /// <param name="uri">Target <see cref="Uri"/> to check</param>
    /// <returns>
    /// <see langword="true"/> if specified <see cref="Uri"/> is accessible; otherwise <see langword="false"/>.
    /// </returns>
    public static async Task<IResult> IsAccessibleAsync(this Uri uri)
    {
        if (uri == null)
        {
            return BooleanResult.CreateErrorResult("url can not be null");
        }

        try
        {
            var request = WebRequest.Create(uri);
            _ = await request.GetResponseAsync();

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }
}
