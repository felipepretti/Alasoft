using ContactManagement.Context;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {
        private readonly MariaDbContext _context;

        public ContactService(MariaDbContext context)
        {
            _context = context;
        }
    }
}