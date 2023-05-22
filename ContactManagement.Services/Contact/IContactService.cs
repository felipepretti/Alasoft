using ContactManagement.Models;

namespace ContactManagement.Services
{
    public interface IContactService
    {
        Task<Contact> AddNewContactAsync(Contact contact);
    }
}