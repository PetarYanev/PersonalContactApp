using FluentAssertions;
using PersonalContactApp.Application.Features.Contacts.Commands.AddContact;
using PersonalContactApp.Domain.Models;
using PersonalContactApp.UnitTests.Factory;
using Xunit;

namespace PersonalContactApp.UnitTests.Application
{
    public class AddContactsValidatorShould
    {
        private readonly AddContactsValidator _sut;

        public AddContactsValidatorShould()
        {
            _sut = new AddContactsValidator();

        }

        [Fact]
        public void ReturnTrueWhenAddContactRequestIsValid()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeTrue();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestFirstNameIsLessThanMinNameLength()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.FirstName = string.Empty;

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestFirstNameExceedsMaxNameLength()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.FirstName = new string('*', ModelConstants.FirstName.MaxNameLength + 1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestSurnameIsLessThanMinNameLength()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.Surname = string.Empty;

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestSurnameExceedsMaxNameLength()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.Surname = new string('*', ModelConstants.Surname.MaxNameLength + 1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestAddressIsLessThanMinAddressLength()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.Address = new string('*', 1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestAddressExceedsMaxAddressLength()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.Address = new string('*', ModelConstants.Address.MaxAddressLength + 1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestPhoneNumberIsNotValid()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.PhoneNumber = new string('*', ModelConstants.Address.MaxAddressLength + 1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestDobIsLessThanMinDob()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.Dob = ModelConstants.Dob.MinDob.AddDays(-1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestDobIsGreaterThanMaxDob()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.Dob = ModelConstants.Dob.MaxDob.AddDays(1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ReturnFalseWhenAddContactRequestIbanIsNotValid()
        {
            //Arrange
            var request = AddContactRequestFakesFactory.GetAddContactRequest();
            request.Iban = new string('*', 50);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            validationResult.IsValid.Should().BeFalse();
        }
    }
}
