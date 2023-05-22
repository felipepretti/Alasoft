using AutoFixture;
using AutoFixture.Xunit2;
using Bogus;
using ContactManagement.Tests.UnitTests.Mocks.Contact;

namespace ContactManagement.Tests.UnitTests.Fixtures
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : this(FixtureFactory)
        {

        }

        public AutoNSubstituteDataAttribute(Func<IFixture> fixtureFactory)
            : base(fixtureFactory)
        {

        }

        public static IFixture FixtureFactory()
        {
            var fixture = new Fixture()
                .Customize(new CommandsCustomization());

            return fixture;
        }

        internal class CommandsCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Register(() => new Faker<ValidContactCommand>("pt_BR")
                     .RuleFor(c => c.Name, "Felipe Pretti")
                     .RuleFor(c => c.Email, "valid@email.com")
                     .RuleFor(c => c.ContactNumber, 123456789)
                     .Generate());

                fixture.Register(() => new Faker<InvalidNameContactCommand>("pt_BR")
                    .RuleFor(c => c.Id, 1)
                    .RuleFor(c => c.Name, "abcd")
                    .RuleFor(c => c.Email, "valid@email.com")
                    .RuleFor(c => c.ContactNumber, 123456789)
                    .Generate());

                fixture.Register(() => new Faker<InvalidEmailContactCommand>("pt_BR")
                    .RuleFor(c => c.Id, 1)
                    .RuleFor(c => c.Name, "Felipe Pretti")
                    .RuleFor(c => c.Email, "invalid@email.")
                    .RuleFor(c => c.ContactNumber, 123456789)
                    .Generate());

                fixture.Register(() => new Faker<InvalidContactNumberContactCommand>("pt_BR")
                    .RuleFor(c => c.Id, 1)
                    .RuleFor(c => c.Name, "Felipe Pretti")
                    .RuleFor(c => c.Email, "valid@email.com")
                    .RuleFor(c => c.ContactNumber, 1234)
                    .Generate());
            }
        }
    }    
}
