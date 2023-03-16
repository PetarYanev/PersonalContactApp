namespace PersonalContactApp.UnitTests.Factory
{
    using Bogus;
    using PersonalContactApp.Application.Features;
    using PersonalContactApp.Application.Features.Contacts.Commands.AddContact;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public static class AddContactRequestFakesFactory
    {
        public static bool CanCreate(Type type) => type == typeof(AddContactRequest);

        public static object? Create(Type type) => GetAddContactRequest();

        public static IEnumerable<AddContactRequest> GetAddContactRequests(int count = 10)
            => Enumerable
                .Range(1, count)
                .Select(i => GetAddContactRequest(i))
                .Concat(Enumerable
                    .Range(count + 1, count * 2)
                    .Select(i => GetAddContactRequest(i)))
                .ToList();

        public static AddContactRequest GetAddContactRequest(int id = 1)
            => new Faker<AddContactRequest>()
                .CustomInstantiator(f => new AddContactRequest()
                {
                    FirstName = f.Lorem.Letter(10),
                    Surname = f.Lorem.Letter(10),
                    Address = f.Lorem.Letter(10),
                    PhoneNumber = $"+{f.Random.Number(100000, 400000)}",
                    Dob = DateOnly.FromDateTime(DateTime.Now.AddYears(-100))
                })
                .Generate()
                .SetId(id);
    }
}
