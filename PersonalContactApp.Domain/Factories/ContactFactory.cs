using PersonalContactApp.Domain.Models.Entities;
using PersonalContactApp.Domain.Models.ValueObjects;

namespace PersonalContactApp.Domain.Factories;

internal class ContactFactory : IContactFactory
{
    private FirstName contactFirstName = default!;
    private Surname contactSurname = default!;
    private Dob contactDob = default!;
    private Address contactAddress = default!;
    private PhoneNumber contactPhoneNumber = default!;
    private Iban contactIban = default!;

    public IContactFactory WithFirstName(string name)
            => WithFirstName(new FirstName(name));

    public IContactFactory WithFirstName(FirstName name)
    {
        contactFirstName = name;
        return this;
    }

    public IContactFactory WithSurname(string name)
            => WithSurname(new Surname(name));

    public IContactFactory WithSurname(Surname name)
    {
        contactSurname = name;
        return this;
    }

    public IContactFactory WithDob(string dob)
            => WithDob(new Dob(dob));

    public IContactFactory WithDob(Dob dob)
    {
        contactDob = dob;
        return this;
    }

    public IContactFactory WithAddress(string address)
            => WithAddress(new Address(address));

    public IContactFactory WithAddress(Address address)
    {
        contactAddress = address;
        return this;
    }

    public IContactFactory WithPhoneNumber(string phoneNumber)
            => WithPhoneNumber(new PhoneNumber(phoneNumber));

    public IContactFactory WithPhoneNumber(PhoneNumber phoneNumber)
    {
        contactPhoneNumber = phoneNumber;
        return this;
    }

    public IContactFactory WithIban(string iban)
            => WithIban(new Iban(iban));

    public IContactFactory WithIban(Iban iban)
    {
        contactIban = iban;
        return this;
    }

    public Contact Build()
    {
        return new Contact
        (
            contactFirstName,
            contactSurname,
            contactDob,
            contactAddress,
            contactPhoneNumber,
            contactIban
        );
    }
}
