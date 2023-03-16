using PersonalContactApp.Domain.Models.Entities;
using PersonalContactApp.Domain.Models.ValueObjects;

namespace PersonalContactApp.Domain.Factories;

public interface IContactFactory : IFactory<Contact>
{
    IContactFactory WithAddress(Address address);
    IContactFactory WithAddress(string address);
    IContactFactory WithDob(Dob dob);
    IContactFactory WithDob(string dob);
    IContactFactory WithFirstName(FirstName name);
    IContactFactory WithFirstName(string name);
    IContactFactory WithIban(Iban iban);
    IContactFactory WithIban(string iban);
    IContactFactory WithPhoneNumber(PhoneNumber phoneNumber);
    IContactFactory WithPhoneNumber(string phoneNumber);
    IContactFactory WithSurname(string name);
    IContactFactory WithSurname(Surname name);
}