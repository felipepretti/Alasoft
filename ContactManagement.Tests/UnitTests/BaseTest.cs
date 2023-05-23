using ContactManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ContactManagement.Tests.UnitTests
{
    public abstract class BaseTest
    {
        protected ApplicationDbContext _context { get; }

        public BaseTest()
        {
            _context = CreateContext();
        }

        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var configuration = new Mock<IConfiguration>();

            return new ApplicationDbContext(configuration.Object, options);
        }
    }
}