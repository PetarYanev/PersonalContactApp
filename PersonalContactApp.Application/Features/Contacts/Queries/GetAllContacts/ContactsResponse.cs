using PersonalContactApp.Application.Features.Contacts.Queries.GetSingleContact;

namespace PersonalContactApp.Application.Features.Contacts.Queries.GetAllContacts;

public class ContactsResponse
{
    public IEnumerable<ContactResponse> Contacts { get; set; }
}
