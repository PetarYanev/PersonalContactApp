using PersonalContactApp.Application.Contracts;
using PersonalContactApp.Application.Features.Contacts.Queries.GetAllContacts;
using PersonalContactApp.Application.Features.Contacts.Queries.GetSingleContact;
using PersonalContactApp.Domain.Models.Entities;

namespace PersonalContactApp.Application.Features.Contacts;

public interface IContactRepository : IRepository<Contact>
{
    Task<ContactResponse> GetContactAsync(int id, CancellationToken cancellationToken = default);
    Task<ContactsResponse> GetAllContactsAsync(CancellationToken cancellationToken = default);
    Task<Contact> Find(int id, CancellationToken cancellationToken = default);
}
