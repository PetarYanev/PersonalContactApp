using MediatR;

namespace PersonalContactApp.Application.Features.Contacts.Commands.AddContact;

public class AddContactRequest : ContactRequest<AddContactRequest>, IRequest<AddContactResponse>
{ }
