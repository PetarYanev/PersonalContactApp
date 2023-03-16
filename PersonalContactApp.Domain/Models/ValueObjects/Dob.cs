using PersonalContactApp.Domain.Common;
using PersonalContactApp.Domain.Exceptions;

namespace PersonalContactApp.Domain.Models.ValueObjects;

public class Dob : ValueObject
{
    public Dob()
    { }

    internal Dob(DateOnly dob)
    {
        Validate(dob);
        Value = dob;
    }

    internal Dob(string dob)
    {
        Validate(dob);
        var date = DateOnly.Parse(dob);
        Validate(date);
        Value = date;
    }

    public DateOnly Value { get; }

    public static implicit operator DateOnly(Dob dob) => dob.Value;
    public static implicit operator Dob(DateOnly dob) => new(dob);

    private void Validate(DateOnly dob)
        => Guard.ForDateBetween<InvalidDobException>(
            dob,
            ModelConstants.Dob.MinDob,
            ModelConstants.Dob.MaxDob,
            nameof(Dob));

    private void Validate(string dob)
        => Guard.ForValidDate<InvalidDobException>(
            dob,
            nameof(Dob));
}
