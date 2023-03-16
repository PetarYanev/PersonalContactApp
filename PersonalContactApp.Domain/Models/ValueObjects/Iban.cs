using PersonalContactApp.Domain.Common;
using PersonalContactApp.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace PersonalContactApp.Domain.Models.ValueObjects;

public class Iban : ValueObject
{
    public Iban()
    { }

    internal Iban(string iban)
    {
        if (!Regex.IsMatch(iban, ModelConstants.Iban.IbanRegularExpression))
        {
            throw new InvalidIbanException("Iban is not valid.");
        }

        Value = iban;
    }

    public string Value { get; }

    public static implicit operator string(Iban iban) => iban.Value;

    public static implicit operator Iban(string iban) => new Iban(iban);
}
