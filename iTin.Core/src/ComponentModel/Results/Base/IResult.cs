﻿
using System.Collections.Generic;

namespace iTin.Core.ComponentModel;

/// <summary>
/// Defines a result.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Gets a value that indicates whether the current operation was executed successfully.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if current operation was executed successfully; otherwise, <see langword="false"/>.
    /// </value>
    bool Success { get; set; }

    /// <summary>
    /// Gets or sets a value that contains an error list.
    /// </summary>
    /// <value>
    /// Error list.
    /// </value>
    IEnumerable<IResultError> Errors { get; set; }

    /// <summary>
    /// Gets or sets a value that contains a warnings list.
    /// </summary>
    /// <value>
    /// Warnings list.
    /// </value>
    IEnumerable<IResultWarning> Warnings { get; set; }
}
