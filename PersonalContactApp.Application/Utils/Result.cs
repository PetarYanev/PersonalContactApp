﻿namespace PersonalContactApp.Application.Utils;

public class Result<TData> : ResultBase
{
    private readonly TData _data;

    private Result(bool succeeded, TData data, List<string> errors)
        : base(succeeded, errors)
        => _data = data;

    public TData Data
        => this.Succeeded
            ? _data
            : throw new InvalidOperationException(
                $"{nameof(Data)} is not available with a failed result. Use {Errors} instead.");

    public static Result<TData> SuccessWith(TData data)
        => new Result<TData>(true, data, new List<string>());

    public new static Result<TData> Failure(IEnumerable<string> errors)
        => new Result<TData>(false, default!, errors.ToList());

    public static implicit operator Result<TData>(string error)
        => Failure(new List<string> { error });

    public static implicit operator Result<TData>(List<string> errors)
        => Failure(errors);

    public static implicit operator Result<TData>(TData data)
        => SuccessWith(data);

    public static implicit operator bool(Result<TData> result)
        => result.Succeeded;
}
