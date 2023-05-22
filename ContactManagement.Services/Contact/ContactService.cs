using ContactManagement.Context;
using ContactManagement.Context.Repository;
using ContactManagement.Context.Repository.Interface;
using ContactManagement.Models;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _repository;

        public ContactService(ContactRepository repository)
        {
            _repository = repository;
        }        
    }
}