
using System;
using System.Net;
using System.Threading.Tasks;

using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;

namespace iTin.Core;

/// <summary>
/// Provides asynchronous extension methods for checking the accessibility of a <see cref="Uri"/>.
/// </summary> 
public static class UriExtensionsAsync
{
    /// <summary>
    /// Asynchronously checks whether the specified <see cref="Uri"/> is accessible.
    /// </summary>
    /// <param name="uri">The <see cref="Uri"/> to check for accessibility.</param>
    /// <returns>
    /// A <see cref="Task{IResult}"/> representing the asynchronous operation. The result of the task is a <see cref="IResult"/> indicating the accessibility status.<br/>
    /// If the <see cref="Uri"/> is accessible, the result is a success; otherwise, it contains an error message.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method attempts to create a <see cref="WebRequest"/> using the specified <see cref="Uri"/> and checks whether a response can be obtained asynchronously.<br/>
    /// If successful, the result is a success; otherwise, it contains an error message.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input <see cref="Uri"/> (<paramref name="uri"/>) is <c>null</c>.</exception>
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
