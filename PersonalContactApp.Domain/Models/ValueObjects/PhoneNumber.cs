using PersonalContactApp.Domain.Common;
using PersonalContactApp.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace PersonalContactApp.Domain.Models.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber()
    { }

    internal PhoneNumber(string number)
    {
        Validate(number);

        if (!Regex.IsMatch(number, ModelConstants.PhoneNumber.PhoneNumberRegularExpression))
        {
            throw new InvalidPhoneNumberException("Phone number must start with a '+' and contain only digits afterwards.");
        }

        Value = number;
    }

    public string Value { get; }

    public static implicit operator string(PhoneNumber number) => number.Value;

    public static implicit operator PhoneNumber(string number) => new(number);

    private void Validate(string phoneNumber)
        => Guard.ForStringLength<InvalidPhoneNumberException>(
            phoneNumber,
            ModelConstants.PhoneNumber.MinPhoneNumberLength,
            ModelConstants.PhoneNumber.MaxPhoneNumberLength,
            nameof(PhoneNumber));
}
