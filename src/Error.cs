namespace ErrorOr;

/// <summary>
/// Represents an error.
/// </summary>
public readonly record struct Error
{
    /// <summary>
    /// Gets the unique error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the error type.
    /// </summary>
    public ErrorType Type { get; }

    /// <summary>
    /// Gets the numeric value of the type.
    /// </summary>
    public int NumericType { get; }

    /// <summary>
    /// Gets the parameters error.
    /// </summary>
    public IEnumerable<string> Parameters { get; }

    /// <summary>
    /// Gets the details of the error.
    /// </summary>
    public string Detail { get; }

    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
        NumericType = (int)type;
        Detail = string.Empty;
        Parameters = Enumerable.Empty<string>();
    }

    private Error(string code, string description, ErrorType type, string detail)
    {
        Code = code;
        Description = description;
        Type = type;
        NumericType = (int)type;
        Detail = detail;
        Parameters = Enumerable.Empty<string>();
    }

    private Error(string code, string description, ErrorType type, IEnumerable<string> parameters)
    {
        Code = code;
        Description = description;
        Type = type;
        NumericType = (int)type;
        Detail = string.Empty;
        Parameters = parameters;
    }

    private Error(string code, string description, ErrorType type, string detail, IEnumerable<string> parameters)
    {
        Code = code;
        Description = description;
        Type = type;
        NumericType = (int)type;
        Detail = detail;
        Parameters = parameters;
    }

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Failure"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    public static Error Failure(
        string code = "General.Failure",
        string description = "A failure has occurred.") =>
        new(code, description, ErrorType.Failure);

    public static Error Failure(
        string code,
        string description,
        string detail) =>
        new(code, description, ErrorType.Validation, detail);

    public static Error Failure(
        string code,
        string description,
        IEnumerable<string> parameters) =>
        new(code, description, ErrorType.Validation, parameters);

    public static Error Failure(
        string code,
        string description,
        string detail,
        IEnumerable<string> parameters) =>
        new(code, description, ErrorType.Validation, detail, parameters);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Unexpected"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    public static Error Unexpected(
        string code = "General.Unexpected",
        string description = "An unexpected error has occurred.") =>
        new(code, description, ErrorType.Unexpected);

    public static Error Unexpected(
        string code = "General.Unexpected",
        string description = "An unexpected error has occurred.",
        string detail = "") =>
        new(code, description, ErrorType.Unexpected, detail);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Validation"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    public static Error Validation(
        string code = "General.Validation",
        string description = "A validation error has occurred.") =>
        new(code, description, ErrorType.Validation);

    public static Error Validation(
        string code,
        string description,
        string detail) =>
        new(code, description, ErrorType.Validation, detail);

    public static Error Validation(
        string code,
        string description,
        IEnumerable<string> parameters) =>
        new(code, description, ErrorType.Validation, parameters);

    public static Error Validation(
        string code,
        string description,
        string detail,
        IEnumerable<string> parameters) =>
        new(code, description, ErrorType.Validation, detail, parameters);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.Conflict"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    public static Error Conflict(
        string code = "General.Conflict",
        string description = "A conflict error has occurred.") =>
        new(code, description, ErrorType.Conflict);

    /// <summary>
    /// Creates an <see cref="Error"/> of type <see cref="ErrorType.NotFound"/> from a code and description.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    public static Error NotFound(
        string code = "General.NotFound",
        string description = "A 'Not Found' error has occurred.") =>
        new(code, description, ErrorType.NotFound);

    public static Error NotFound(
        string code = "General.NotFound",
        string description = "A 'Not Found' error has occurred.",
        string detail = "") =>
        new(code, description, ErrorType.NotFound, detail);

    public static Error NotFound(
        string code,
        string description,
        string detail,
        IEnumerable<string> parameters) =>
        new(code, description, ErrorType.NotFound, detail, parameters);

    /// <summary>
    /// Creates an <see cref="Error"/> with the given numeric <paramref name="type"/>,
    /// <paramref name="code"/>, and <paramref name="description"/>.
    /// </summary>
    /// <param name="type">An integer value which represents the type of error that occurred.</param>
    /// <param name="code">The unique error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="parameters">The parameters errors.</param>
    public static Error Custom(
        int type,
        string code,
        string description,
        IEnumerable<string> parameters) =>
        new(code, description, (ErrorType)type, parameters);

    public static Error Custom(
        int type,
        string code,
        string description) =>
        new(code, description, (ErrorType)type);

    public static Error Custom(
        int type,
        string code,
        string description,
        string detail,
        IEnumerable<string> parameters) =>
        new(code, description, (ErrorType)type, detail, parameters);
}
