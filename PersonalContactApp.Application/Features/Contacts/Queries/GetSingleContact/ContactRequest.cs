using MediatR;

namespace PersonalContactApp.Application.Features.Contacts.Queries.GetSingleContact;

public class ContactRequest : IRequest<ContactResponse>
{
    public int Id { get; set; }
}
