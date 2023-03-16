using FluentValidation;

namespace PersonalContactApp.Application.Features.Contacts.Commands.AddContact;

public class AddContactsValidator : AbstractValidator<AddContactRequest>
{
    public AddContactsValidator()
            => Include(new ContactValidator<AddContactRequest>());
}
