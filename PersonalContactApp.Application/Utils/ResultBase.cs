namespace PersonalContactApp.Application.Utils;

public class ResultBase
{
    private readonly List<string> _errors;

    internal ResultBase(bool succeeded, List<string> errors)
    {
        Succeeded = succeeded;
        _errors = errors;
    }

    public bool Succeeded { get; }

    public List<string> Errors
        => Succeeded
            ? new List<string>()
            : _errors;

    public static ResultBase Success
        => new ResultBase(true, new List<string>());

    public static ResultBase Failure(IEnumerable<string> errors)
        => new ResultBase(false, errors.ToList());

    public static implicit operator ResultBase(string error)
        => Failure(new List<string> { error });

    public static implicit operator ResultBase(List<string> errors)
        => Failure(errors.ToList());

    public static implicit operator ResultBase(bool success)
        => success ? Success : Failure(new[] { "Unsuccessful operation." });

    public static implicit operator bool(ResultBase result)
        => result.Succeeded;
}
