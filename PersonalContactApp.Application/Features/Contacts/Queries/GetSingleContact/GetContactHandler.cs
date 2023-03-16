using MediatR;

namespace PersonalContactApp.Application.Features.Contacts.Queries.GetSingleContact;

public class GetContactHandler : IRequestHandler<ContactRequest, ContactResponse>
{
    private readonly IContactRepository _contactRepository;

    public GetContactHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ContactResponse> Handle(ContactRequest request, CancellationToken cancellationToken)
    {
        var response = await _contactRepository.GetContactAsync(request.Id, cancellationToken);
        return response;
    }
}
