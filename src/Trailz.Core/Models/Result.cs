namespace Trailz.Core.Models;

public record Error(string Message, string Code);

public record Result
{
    public Error? Error { get; }
    public bool IsSuccess => Error is null;

    protected Result()
    {
        Error = null;
    }

    protected Result(Error error)
    {
        Error = error;
    }

    public static Result Success() => new();
    public static Result Failure(Error error) => new(error);
}

public record Result<T> : Result
{
    public T? Value { get; }

    private Result(T value) : base()
    {
        Value = value;
    }

    private Result(Error error) : base(error)
    {
        Value = default;
    }

    public static Result<T> Success(T value) => new(value);
    public new static Result<T> Failure(Error error) => new(error);
}
