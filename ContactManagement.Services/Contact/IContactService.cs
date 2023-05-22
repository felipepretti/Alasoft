using ContactManagement.Models;

namespace ContactManagement.Services
{
    public interface IContactService
    {
        Task<Contact> AddOrUpdateContactAsync(Contact contact);
        IQueryable<Contact> GetAllContacts();
        void DeleteContact(Contact contact);
    }
}