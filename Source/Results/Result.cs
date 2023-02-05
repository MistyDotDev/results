namespace MistyDotDev.Results;

/// <summary>
/// The result of an operation.
/// </summary>
public readonly struct Result
{
    /// <summary>
    /// The outcome of the operation.
    /// </summary>
    public ResultStatus Status { get; }

    /// <summary>
    /// True if <see cref="Status"/> is set to <see cref="ResultStatus.Success"/>.
    /// </summary>
    public bool IsSuccess => Status is ResultStatus.Success;

    /// <summary>
    /// True if <see cref="Status"/> is set to <see cref="ResultStatus.Failure"/>.
    /// </summary>
    public bool IsFailure => Status is ResultStatus.Failure;

    /// <summary>
    /// Creates a result with the given status.
    /// </summary>
    public Result(ResultStatus status)
    {
        Status = status;
    }

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Success"/>.
    /// </summary>
    public static Result Success() => new(ResultStatus.Success);

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Failure"/>.
    /// </summary>
    public static Result Failure() => new(ResultStatus.Failure);
}

/// <summary>
/// The result of an operation.
/// </summary>
/// <typeparam name="TValue">The type provided by either of the outcomes.</typeparam>
public readonly struct Result<TValue>
{
    /// <summary>
    /// The value provided by the operation.
    /// </summary>
    public TValue? Value { get; }

    /// <summary>
    /// The outcome of the operation.
    /// </summary>
    public ResultStatus Status { get; }

    /// <summary>
    /// True if <see cref="Status"/> is set to <see cref="ResultStatus.Success"/>.
    /// </summary>
    public bool IsSuccess => Status is ResultStatus.Success;

    /// <summary>
    /// True if <see cref="Status"/> is set to <see cref="ResultStatus.Failure"/>.
    /// </summary>
    public bool IsFailure => Status is ResultStatus.Failure;

    /// <summary>
    /// Creates a result with the given status.
    /// </summary>
    public Result(ResultStatus status, TValue? value)
    {
        Status = status;
        Value = value;
    }

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Success"/>.
    /// This leaves <see cref="Value"/> as its default value.
    /// </summary>
    public static Result<TValue> Success() => new(ResultStatus.Success, default);

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Success"/>.
    /// </summary>
    public static Result<TValue> Success(TValue value) => new(ResultStatus.Success, value);

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Failure"/>.
    /// This leaves <see cref="Value"/> as its default value.
    /// </summary>
    public static Result<TValue> Failure() => new(ResultStatus.Failure, default);

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Failure"/>.
    /// </summary>
    public static Result<TValue> Failure(TValue value) => new(ResultStatus.Failure, value);
}

/// <summary>
/// The result of an operation.
/// </summary>
/// <typeparam name="TFailure">The type provided in the <see cref="ResultStatus.Failure"/> state.</typeparam>
/// <typeparam name="TSuccess">The type provided in the <see cref="ResultStatus.Success"/> state.</typeparam>
public readonly struct Result<TFailure, TSuccess>
{
    /// <summary>
    /// The value set if <see cref="Status"/> is set to <see cref="ResultStatus.Success"/>.
    /// </summary>
    public TSuccess? Value { get; }

    /// <summary>
    /// The value set if <see cref="Status"/> is set to <see cref="ResultStatus.Failure"/>.
    /// </summary>
    public TFailure? Error { get; }

    /// <summary>
    /// The outcome of the operation.
    /// </summary>
    public ResultStatus Status { get; }

    /// <summary>
    /// True if <see cref="Status"/> is set to <see cref="ResultStatus.Success"/>.
    /// </summary>
    public bool IsSuccess => Status is ResultStatus.Success;

    /// <summary>
    /// True if <see cref="Status"/> is set to <see cref="ResultStatus.Failure"/>.
    /// </summary>
    public bool IsFailure => Status is ResultStatus.Failure;

    /// <summary>
    /// Creates a result with the given status.
    /// </summary>
    public Result(ResultStatus status, TFailure? error, TSuccess? value)
    {
        Status = status;
        Error = error;
        Value = value;
    }

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Success"/>.
    /// </summary>
    public static Result<TFailure, TSuccess> Success(TSuccess value) => new(ResultStatus.Success, default, value);

    /// <summary>
    /// Creates a result with <see cref="Status"/> set to <see cref="ResultStatus.Failure"/>.
    /// </summary>
    public static Result<TFailure, TSuccess> Failure(TFailure error) => new(ResultStatus.Failure, error, default);
}