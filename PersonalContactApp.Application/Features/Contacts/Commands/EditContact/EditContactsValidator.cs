using FluentValidation;

namespace PersonalContactApp.Application.Features.Contacts.Commands.EditContact;

public class EditContactsValidator : AbstractValidator<EditContactRequest>
{
    public EditContactsValidator()
            => Include(new ContactValidator<EditContactRequest>());
}
