using ContactManagement.Context;
using ContactManagement.Context.Repository;
using ContactManagement.Services;
using ContactManagement.Tests.UnitTests.Fixtures;
using ContactManagement.Tests.UnitTests.Mocks.Contact;
using FluentAssertions;
using NSubstitute;

namespace ContactManagement.Tests.UnitTests.Application.Services
{
    public class ContactServiceTest : BaseTest
    {
        private readonly ContactService service;
        private readonly ContactRepository repository;

        public ContactServiceTest()
        {
            repository = Substitute.For<ContactRepository>(_context);
            service = Substitute.For<ContactService>(repository);            
        }

        [Theory(DisplayName = "Should save contact | when valid data")]
        [AutoNSubstituteData]
        public async Task ShouldSaveContactWhenValidData(ValidContactCommand contact)

        {
            var result = await service.AddOrUpdateContactAsync(contact);
            result.Should().Be(contact);
        }

        [Theory(DisplayName = "Should throw exception | when invalid name")]
        [AutoNSubstituteData]
        public async Task ShouldThrowExceptionWhenInvalidName(InvalidNameContactCommand contact)

        {
            await Assert.ThrowsAsync<Exception>(() => service.AddOrUpdateContactAsync(contact));
        }

        [Theory(DisplayName = "Should throw exception | when invalid e-mail")]
        [AutoNSubstituteData]
        public async Task ShouldThrowExceptionWhenInvalidEmail(InvalidEmailContactCommand contact)

        {
            await Assert.ThrowsAsync<Exception>(() => service.AddOrUpdateContactAsync(contact));
        }

        [Theory(DisplayName = "Should throw exception | when invalid contact number")]
        [AutoNSubstituteData]
        public async Task ShouldThrowExceptionWhenInvalidContactNumber(InvalidContactNumberContactCommand contact)

        {
            await Assert.ThrowsAsync<Exception>(() => service.AddOrUpdateContactAsync(contact));
        }
    }
}
