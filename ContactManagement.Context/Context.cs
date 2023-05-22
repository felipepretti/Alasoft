using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ContactManagement.Context
{
    public class MariaDbContext : DbContext
    {
        private IConfiguration Configuration { get; set; }

        public MariaDbContext()
        { }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            
            optionsBuilder.UseMySQL("Server=localhost;Database=db;User Id=root;Password=root");
        }

        public DbSet<Contact> Contact { get; set; }
    }
}
