namespace PersonalContactApp.Application.Features.Contacts.Commands.AddContact;

public class AddContactResponse
{
    public AddContactResponse(int id) => Id = id;
    public int Id { get; set; }
}
