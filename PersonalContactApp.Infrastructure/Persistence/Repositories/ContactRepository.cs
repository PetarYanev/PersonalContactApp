using Microsoft.EntityFrameworkCore;
using PersonalContactApp.Application.Features.Contacts;
using PersonalContactApp.Application.Features.Contacts.Queries.GetAllContacts;
using PersonalContactApp.Application.Features.Contacts.Queries.GetSingleContact;
using PersonalContactApp.Domain.Models.Entities;

namespace PersonalContactApp.Infrastructure.Persistence.Repositories;

internal class ContactRepository : DataRepository<Contact>, IContactRepository
{
    public ContactRepository(PersonalContactDbContext db)
            : base(db)
    { }

    public async Task<ContactResponse> GetContactAsync(int id, CancellationToken cancellationToken = default)
    {
        var contact = await All()
                                .Where(d => d.Id == id)
                                .Select(e => new ContactResponse
                                {
                                    Id = e.Id,
                                    FirstName = e.FirstName,
                                    Surname = e.Surname,
                                    Dob = e.Dob,
                                    Address = e.Address,
                                    PhoneNumber = e.PhoneNumber,
                                    Iban = e.Iban,
                                })
                                .FirstOrDefaultAsync(cancellationToken);
        return contact;
    }

    public async Task<ContactsResponse> GetAllContactsAsync(CancellationToken cancellationToken = default)
    {
        var contacts = await All()
                                .Select(e => new ContactResponse
                                {
                                    Id= e.Id,
                                    FirstName = e.FirstName.Value,
                                    Surname = e.Surname.Value,
                                    Dob = e.Dob.Value,
                                    Address = e.Address.Value,
                                    PhoneNumber = e.PhoneNumber.Value,
                                    Iban = e.Iban.Value,
                                })
                                .ToListAsync(cancellationToken);

        var result = new ContactsResponse { Contacts = contacts };
            return result;
    }

    public async Task<Contact> Find(int id, CancellationToken cancellationToken = default)
    {
        return await All()
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
