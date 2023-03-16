namespace PersonalContactApp.Domain.Exceptions;

public class InvalidSurnameException : BaseDomainException
{
	public InvalidSurnameException()
	{}

    public InvalidSurnameException(string error) => Error = error;
}
