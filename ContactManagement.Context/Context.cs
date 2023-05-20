using System.Data.SqlClient;
using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ContactManagement.Context
{
    public class MariaDbContext : DbContext
    {
        private IConfiguration Configuration { get; }

        public MariaDbContext()
        {
            
        }

        public MariaDbContext(IConfiguration _configuration, DbContextOptions<MariaDbContext> options)
        : base(options)
        {
            Configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            //Configuration["ConnectionStrings:MariaDb"]
            var connection = new MySqlConnection("server=127.0.0.1;user id=root;password=root;database=db");

            optionsBuilder.UseMySQL(connection);
        }

        public DbSet<Contact> Contact { get; set; }
    }
}
