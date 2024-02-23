using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Shared;
public class Result
{
    protected Result()
    {
        IsSuccess = true;
        Error = Error.None;
    }

    protected Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; private set; }

    public static Result Success => new();

    public static Result Failure(Error error) => new(error);
}
