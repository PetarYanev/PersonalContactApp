namespace PersonalContactApp.Domain.Models;

public class ModelConstants
{
    public class FirstName
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
    }

    public class Surname
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
    }

    public class Address
    {
        public const int MinAddressLength = 5;
        public const int MaxAddressLength = 50;
    }

    public class Dob
    {
        public const int MaxAddressLength = 50;
        public static readonly DateOnly MinDob = DateOnly.FromDateTime(DateTime.Now.AddYears(-150));
        public static readonly DateOnly MaxDob = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
    }

    public class PhoneNumber
    {
        public const int MinPhoneNumberLength = 5;
        public const int MaxPhoneNumberLength = 20;
        public const string PhoneNumberRegularExpression = @"\+[0-9]*";
    }

    public class Iban
    {
        public const string IbanRegularExpression = @"\b[A-Z]{2}[0-9]{2}[A-Z0-9]{4}[0-9]{7}([A-Z0-9]?){0,16}\b";
    }
}
