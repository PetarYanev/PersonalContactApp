using PersonalContactApp.Domain.Common;
using PersonalContactApp.Domain.Exceptions;

namespace PersonalContactApp.Domain.Models.ValueObjects;

public class FirstName : ValueObject
{
    public FirstName()
    { }

    internal FirstName(string firstName)
    {
        Validate(firstName);
        Value = firstName;
    }

    public string Value { get; }

    public static implicit operator string(FirstName firstName) => firstName.Value;
    public static implicit operator FirstName(string firstName) => new(firstName);

    private void Validate(string firstName)
        => Guard.ForStringLength<InvalidFirstNameException>(
            firstName,
            ModelConstants.FirstName.MinNameLength,
            ModelConstants.FirstName.MaxNameLength,
            nameof(FirstName));
}
