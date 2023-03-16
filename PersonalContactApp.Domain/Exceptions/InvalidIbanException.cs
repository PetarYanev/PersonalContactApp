namespace PersonalContactApp.Domain.Exceptions;

public class InvalidIbanException : BaseDomainException
{
    public InvalidIbanException()
    { }

    public InvalidIbanException(string error) => Error = error;
}

