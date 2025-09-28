using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trailz.Core.Models
{
    public readonly record struct Error(string message, string code);

    public readonly record struct Result<T>
    {
        public Error? Error { get; }

        public T? Value { get; }

        public bool IsSuccess => Error is null;

        private Result(T value)
        {
            Value = value;
            Error = null;
        }

        private Result(Error error)
        {
            Value = default;
            Error = error;
        }

        public static Result<T> Success(T value) => new(value);
        public static Result<T> Failure(Error error) => new(error);
    }
}
