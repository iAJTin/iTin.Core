
using System.Diagnostics;
using System.Text;
using System.Threading;

using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Enums;

using NativeSystem = System;

namespace iTin.Core.Helpers;

/// <summary>
/// A utility class providing helper methods related to the system environment and process execution.
/// </summary>
public static class SystemHelper
{
    /// <summary>
    /// Gets a value indicating whether the operating system is a 32-bit system.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the operating system is 32-bit; otherwise, <see langword="false"/>.
    /// </value>
    /// <remarks>
    /// This property checks if the operating system is not a 64-bit system.
    /// </remarks>
    public static bool Is32BitOperatingSystem => !Is64BitOperatingSystem;

    /// <summary>
    /// Gets a value indicating whether the operating system is a 64-bit system.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the operating system is 64-bit; otherwise, <see langword="false"/>.
    /// </value>
    /// <remarks>
    /// This property relies on the underlying system's information to determine if the operating system is 64-bit.
    /// </remarks>
    public static bool Is64BitOperatingSystem => NativeSystem.Environment.Is64BitOperatingSystem;

    /// <summary>
    /// Executes a command-line program with the specified arguments and captures its standard output.
    /// </summary>
    /// <param name="program">The path or name of the program to run.</param>
    /// <param name="arguments">The command-line arguments to pass to the program.</param>
    /// <returns>
    /// A <see cref="StringBuilder"/> containing the standard output of the executed program.
    /// </returns>
    /// <remarks>
    /// This method runs a command-line program in a hidden window, captures its standard output,
    /// and returns the output as a <see cref="StringBuilder"/>.
    /// </remarks>
    public static StringBuilder RunCommand(string program, string arguments)
    {
        var pi = new ProcessStartInfo(program, arguments)
        {
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        using var process = Process.Start(pi);
        var builder = new StringBuilder();

        if (process == null)
        {
            return builder;
        }

        while (!process.StandardOutput.EndOfStream)
        {
            builder.AppendLine(process.StandardOutput.ReadLine());
        }

        return builder;
    }

    /// <summary>
    /// Executes a command-line program represented by the specified <see cref="WinProgram"/> enum
    /// with the specified arguments and captures its standard output.
    /// </summary>
    /// <param name="program">The <see cref="WinProgram"/> enum representing the program to run.</param>
    /// <param name="arguments">The command-line arguments to pass to the program.</param>
    /// <returns>
    /// A <see cref="StringBuilder"/> containing the standard output of the executed program.
    /// </returns>
    /// <remarks>
    /// This method runs a command-line program in a hidden window, captures its standard output,
    /// and returns the output as a <see cref="StringBuilder"/>.
    /// </remarks>
    public static StringBuilder RunCommand(WinProgram program, string arguments) => RunCommand(program.GetDescription(), arguments);

    /// <summary>
    /// Runs a program with the specified arguments and provides options for execution control.
    /// </summary>
    /// <param name="program">The path or name of the program to run.</param>
    /// <param name="arguments">The command-line arguments to pass to the program.</param>
    /// <param name="options">Options for controlling the execution of the program (optional).</param>
    /// <remarks>
    /// This method starts a new process to run the specified program with the provided arguments.
    /// Additional options, such as controlling whether to use the shell for execution and introducing a sleep time after starting the process, can be specified through the <paramref name="options"/> parameter.
    /// </remarks>
    public static void RunProgram(string program, string arguments, RunProgramOptions options = null)
    {
        var safeOptions = options;
        if (options == null)
        {
            safeOptions = RunProgramOptions.Default;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo(program, arguments) { UseShellExecute = safeOptions.UseShellExecute };
        using (Process.Start(startInfo))
        {
            // Nothing to do
        }

        if (safeOptions.SleepTime > 0)
        {
            Thread.Sleep(safeOptions.SleepTime);
        }
    }

    /// <summary>
    /// Runs a command-line program represented by the specified <see cref="WinProgram"/> enum
    /// with the specified arguments and provides options for execution control.
    /// </summary>
    /// <param name="program">The <see cref="WinProgram"/> enum representing the program to run.</param>
    /// <param name="arguments">The command-line arguments to pass to the program.</param>
    /// <param name="options">Options for controlling the execution of the program (optional).</param>
    /// <remarks>
    /// This method starts a new process to run the command-line program represented by the <see cref="WinProgram"/> enum with the provided arguments.
    /// Additional options, such as controlling whether to use the shell for execution and introducing a sleep time after starting the process, can be specified through the <paramref name="options"/> parameter.
    /// </remarks>
    public static void RunProgram(WinProgram program, string arguments, RunProgramOptions options = null) =>
        RunProgram(program.GetDescription(), arguments, options ?? RunProgramOptions.Default);
}
