using MediatR;

namespace PersonalContactApp.Application.Features.Contacts.Queries.GetAllContacts;

public class AllContactsRequest : IRequest<ContactsResponse>
{ }
