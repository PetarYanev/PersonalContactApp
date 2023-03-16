namespace PersonalContactApp.Domain.Exceptions;

public class InvalidDobException : BaseDomainException
{
    public InvalidDobException()
    {}

    public InvalidDobException(string error) => Error = error;
}