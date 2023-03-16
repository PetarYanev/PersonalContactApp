namespace PersonalContactApp.Application.Features.Contacts.Commands;

public class ContactRequest<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public DateOnly Dob { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Iban { get; set; }
}
