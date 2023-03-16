using PersonalContactApp.Domain.Common;
using PersonalContactApp.Domain.Exceptions;

namespace PersonalContactApp.Domain.Models.ValueObjects;

public class Surname : ValueObject
{
    public Surname()
    { }

    internal Surname(string surname)
    {
        Validate(surname);
        Value = surname;
    }

    public string Value { get; }

    public static implicit operator string(Surname surname) => surname.Value;
    public static implicit operator Surname(string surname) => new(surname);

    private void Validate(string surname)
        => Guard.ForStringLength<InvalidSurnameException>(
            surname,
            ModelConstants.Surname.MinNameLength,
            ModelConstants.Surname.MaxNameLength,
            nameof(Surname));
}
