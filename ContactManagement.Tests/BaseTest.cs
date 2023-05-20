using ContactManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ContactManagement.Tests
{
    public abstract class BaseTest
    {
        protected MariaDbContext _context { get; }

        public BaseTest()
        {
            _context = CreateContext();
        }

        private Context.MariaDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<MariaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var configuration = new Mock<IConfiguration>();

            return new Context.MariaDbContext(configuration.Object, (DbContextOptions<MariaDbContext>)options);
        }
    }
}