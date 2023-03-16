namespace PersonalContactApp.Domain.Exceptions;

public class InvalidPhoneNumberException : BaseDomainException
{
	public InvalidPhoneNumberException()
	{}

    public InvalidPhoneNumberException(string error) => Error = error;
}
