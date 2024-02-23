﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Shared;
public class Result<TValue, TError> : Result where TError : Error
{
    private readonly TValue _value;
    private readonly TError _error;

    public Result(TValue value) : base()
    {
        _value = value;
    }

    public Result(TError error) : base(error)
    {
        _error = error;
    }

    public TValue Value => IsSuccess ? _value :
        throw new Exception("Value can not be accessed");

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    public TResult Match<TResult>(Func<TValue, TResult> success, Func<TError, TResult> failure) =>
        IsSuccess ? success(_value) : failure(_error);
}
