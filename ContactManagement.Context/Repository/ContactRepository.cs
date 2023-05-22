using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Context.Repository
{
    public class ContactRepository : GenericRepository<Contact>
    {
        public ContactRepository(MariaDbContext context)
            : base(context)
        {
        }

        public async Task<Contact> AddNewContactAsync(Contact contact)
        {
            AddOrUpdate(contact);
            await SaveChangesAsync();

            return contact;
        }
    }
}
