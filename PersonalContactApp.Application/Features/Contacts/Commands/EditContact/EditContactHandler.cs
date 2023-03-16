using MediatR;
using PersonalContactApp.Application.Utils;

namespace PersonalContactApp.Application.Features.Contacts.Commands.EditContact;

public class EditContactHandler : IRequestHandler<EditContactRequest, ResultBase>
{
    private readonly IContactRepository _contactRepository;

    public EditContactHandler(IContactRepository contactRepository)
	{
        _contactRepository = contactRepository;
    }

    public async Task<ResultBase> Handle(EditContactRequest request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.Find(request.Id, cancellationToken);
        if (contact == null) 
        { 
            return ResultBase.Failure(new List<string> { $"Contact with id: {request.Id} do not exist."});
        }

        contact.UpdateFirstName(request.FirstName)
            .UpdateSurname(request.Surname)
            .UpdateAddress(request.Address)
            .UpdateDob(request.Dob)
            .UpdatePhoneNumber(request.PhoneNumber)
            .UpdateIban(request.Iban);

        await _contactRepository.Save(contact, cancellationToken);

        return ResultBase.Success;
    }
}
