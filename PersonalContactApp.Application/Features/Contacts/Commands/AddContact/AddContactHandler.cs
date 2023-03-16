using MediatR;
using PersonalContactApp.Domain.Factories;

namespace PersonalContactApp.Application.Features.Contacts.Commands.AddContact;

public class AddContactHandler : IRequestHandler<AddContactRequest, AddContactResponse>
{
    private readonly IContactRepository _contactRepository;
    private readonly IContactFactory _contactFactory;

    public AddContactHandler(IContactRepository contactRepository, IContactFactory contactFactory)
    {
        _contactRepository = contactRepository;
        _contactFactory = contactFactory;
    }

    public async Task<AddContactResponse> Handle(AddContactRequest request, CancellationToken cancellationToken)
    {
        var contact = _contactFactory
            .WithFirstName(request.FirstName)
            .WithSurname(request.Surname)
            .WithDob(request.Dob)
            .WithAddress(request.Address)
            .WithPhoneNumber(request.PhoneNumber)
            .WithIban(request.Iban)
            .Build();

        await _contactRepository.Save(contact, cancellationToken);
        return new AddContactResponse(contact.Id);
    }
}
