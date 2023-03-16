using PersonalContactApp.Domain.Common;
using PersonalContactApp.Domain.Models.ValueObjects;

namespace PersonalContactApp.Domain.Models.Entities;

public class Contact : Entity<int>, IAggregateRoot
{
    public Contact()
    { }

    public Contact(string firstName, string surname, DateOnly dob, string address, string phoneNumber, string iban)
    {
        FirstName = firstName;
        Surname = surname;
        Dob = dob;
        Address = address;
        PhoneNumber = phoneNumber;
        Iban = iban;
    }

    public FirstName FirstName { get; private set; }
    public Surname Surname { get; private set; }
    public Dob Dob { get; private set; }
    public Address Address { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Iban Iban { get; private set; }

    public Contact UpdateFirstName(string firstName)
    {
        FirstName = firstName;
        return this;
    }

    public Contact UpdateSurname(string surname)
    {
        Surname = surname;
        return this;
    }

    public Contact UpdateDob(DateOnly dob)
    {
        Dob = dob;
        return this;
    }

    public Contact UpdateAddress(string address)
    {
        Address = address;
        return this;
    }

    public Contact UpdatePhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return this;
    }

    public Contact UpdateIban(string iban)
    {
        Iban = iban;
        return this;
    }
}
