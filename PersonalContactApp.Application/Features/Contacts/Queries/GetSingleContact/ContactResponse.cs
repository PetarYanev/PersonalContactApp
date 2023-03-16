namespace PersonalContactApp.Application.Features.Contacts.Queries.GetSingleContact;

public class ContactResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public DateOnly Dob { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Iban { get; set; }
}
