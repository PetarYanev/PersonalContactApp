using PersonalContactApp.Domain.Exceptions;

namespace PersonalContactApp.Domain.Common;

public static class Guard
{
    public static void AgainstEmptyString<TException>(string value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (!string.IsNullOrEmpty(value))
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null ot empty.");
    }

    public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstEmptyString<TException>(value, name);

        if (minLength <= value.Length && value.Length <= maxLength)
        {
            return;
        }

        ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
    }

    public static void ForDateBetween<TException>(DateOnly value, DateOnly minDate, DateOnly maxDate, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (minDate <= value && value <= maxDate)
        {
            return;
        }

        ThrowException<TException>($"{name} must have between {minDate} and {maxDate}.");
    }

    public static void ForValidDate<TException>(string value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (DateOnly.TryParse(value, out var date))
        {
            return;
        }

        ThrowException<TException>($"{name} must be valid date.");
    }

    private static void ThrowException<TException>(string message)
        where TException : BaseDomainException, new()
    {
        var exception = new TException
        {
            Error = message
        };

        throw exception;
    }
}
