using MediatR;

namespace PersonalContactApp.Application.Features.Contacts.Queries.GetAllContacts;

public class GetAllContactsHandler : IRequestHandler<AllContactsRequest, ContactsResponse>
{
    private readonly IContactRepository _contactRepository;

    public GetAllContactsHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }


    public async Task<ContactsResponse> Handle(AllContactsRequest request, CancellationToken cancellationToken)
    {
        var response = await _contactRepository.GetAllContactsAsync(cancellationToken);
        return response;
    }
}
