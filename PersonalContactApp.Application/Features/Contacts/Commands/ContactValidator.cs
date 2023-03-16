using FluentValidation;
using PersonalContactApp.Domain.Models;

namespace PersonalContactApp.Application.Features.Contacts.Commands;

public class ContactValidator<TCommand> : AbstractValidator<ContactRequest<TCommand>>
        where TCommand : EntityCommand<int>
{
    public ContactValidator()
    {
        RuleFor(c => c.FirstName)
                .MinimumLength(ModelConstants.FirstName.MinNameLength)
                .MaximumLength(ModelConstants.FirstName.MaxNameLength)
                .NotEmpty();

        RuleFor(c => c.Surname)
                .MinimumLength(ModelConstants.Surname.MinNameLength)
                .MaximumLength(ModelConstants.Surname.MaxNameLength)
                .NotEmpty();

        RuleFor(c => c.Address)
                .MinimumLength(ModelConstants.Address.MinAddressLength)
                .MaximumLength(ModelConstants.Address.MaxAddressLength);

        RuleFor(c => c.Dob)
                .InclusiveBetween(ModelConstants.Dob.MinDob, ModelConstants.Dob.MaxDob)
                .NotEmpty();

        RuleFor(c => c.PhoneNumber)
                .MinimumLength(ModelConstants.PhoneNumber.MinPhoneNumberLength)
                .MaximumLength(ModelConstants.PhoneNumber.MaxPhoneNumberLength)
                .Matches(ModelConstants.PhoneNumber.PhoneNumberRegularExpression)
                .NotEmpty();

        RuleFor(c => c.Iban)
                .Matches(ModelConstants.Iban.IbanRegularExpression);
    }
}
