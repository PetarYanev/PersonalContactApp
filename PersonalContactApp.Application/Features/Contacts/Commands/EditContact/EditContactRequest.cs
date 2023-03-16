using MediatR;
using PersonalContactApp.Application.Utils;

namespace PersonalContactApp.Application.Features.Contacts.Commands.EditContact;

public class EditContactRequest : ContactRequest<EditContactRequest>, IRequest<ResultBase>
{ }
