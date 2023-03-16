using PersonalContactApp.Domain.Common;
using PersonalContactApp.Domain.Exceptions;

namespace PersonalContactApp.Domain.Models.ValueObjects;

public class Address : ValueObject
{
    public Address()
    { }

    internal Address(string address)
    {
        Validate(address);
        Value = address;
    }

    public string Value { get; }

    public static implicit operator string(Address address) => address.Value;
    public static implicit operator Address(string address) => new(address);

    private void Validate(string address)
        => Guard.ForStringLength<InvalidAddressException>(
            address,
            ModelConstants.Address.MinAddressLength,
            ModelConstants.Address.MaxAddressLength,
            nameof(Address));
}
