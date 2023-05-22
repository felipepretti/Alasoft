using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ContactManagement.Context
{
    public class MariaDbContext : DbContext
    {
        private IConfiguration @object;
        private DbContextOptions<MariaDbContext> options;

        private IConfiguration Configuration { get; set; }

        public MariaDbContext()
        { }

        public MariaDbContext(IConfiguration configuration, DbContextOptions<MariaDbContext> options)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            //For EF update-database command.
            var connectionString = "Server=localhost;Database=db;User Id=root;Password=root";

            if (Configuration is not null)
            {
                connectionString = Configuration.GetConnectionString("MariaDb");
            }

            optionsBuilder.UseMySQL();
        }

        public DbSet<Contact> Contact { get; set; }
    }
}
