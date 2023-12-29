
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace iTin.Core.Helpers;

/// <summary>
/// A utility class providing asynchronous helper methods related to running command-line programs.
/// </summary>
public static class SystemHelperAsync
{
    /// <summary>
    /// Asynchronously executes a command-line program with the specified arguments and captures its standard output.
    /// </summary>
    /// <param name="program">The path or name of the program to run.</param>
    /// <param name="arguments">The command-line arguments to pass to the program.</param>
    /// <returns>
    /// A <see cref="StringBuilder"/> containing the standard output of the executed program.
    /// </returns>
    /// <remarks>
    /// This method asynchronously runs a command-line program in a hidden window, captures its standard output,
    /// and returns the output as a <see cref="StringBuilder"/>.
    /// </remarks>
    public static async Task<StringBuilder> RunCommandAsync(string program, string arguments)
    {
        var tcs = new TaskCompletionSource<int>();
        var builder = new StringBuilder();

        var pi = new ProcessStartInfo(program, arguments)
        {
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        var process = new Process
        {
            StartInfo = pi,
            EnableRaisingEvents = true
        };

        process.Exited += (sender, args) =>
        {
            tcs.SetResult(process.ExitCode);
            process.Dispose();
        };

        process.Start();
        while (!process.StandardOutput.EndOfStream)
        {
            builder.AppendLine(await process.StandardOutput.ReadLineAsync());
        }

        return builder;
    }
}
