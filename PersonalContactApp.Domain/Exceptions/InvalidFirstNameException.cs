namespace PersonalContactApp.Domain.Exceptions;

public class InvalidFirstNameException : BaseDomainException
{
	public InvalidFirstNameException()
	{}

    public InvalidFirstNameException(string error) => Error = error;
}
