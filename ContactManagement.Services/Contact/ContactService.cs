using ContactManagement.Context;
using ContactManagement.Context.Repository;
using ContactManagement.Context.Repository.Interface;
using ContactManagement.Models;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _repository;

        public ContactService(ContactRepository repository)
        {
            _repository = repository;
        }        

        public async Task<Contact> AddOrUpdateContactAsync(Contact contact)
        {
            IsValidName(contact.Name);
            IsValidContactNumber(contact.ContactNumber);
            IsValidateEmail(contact.Email);

            return await _repository.AddOrUpdateContactAsync(contact);
        }

        public IQueryable<Contact> GetAllContacts()
        {
            return _repository.GetAll();
        }

        public void DeleteContact(Contact contact)
        {
            _repository.Delete(contact);
        }

        private void IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 5)
            {
                throw new Exception("Name must be at least 5 characters.");
            }
        }

        private void IsValidContactNumber(int number)
        {
            if (!int.TryParse(number.ToString(), out number))
            {
                throw new Exception("Only 0-9 digits are allowed.");
            }

            if(number.ToString().Length != 9)
            {
                throw new Exception("Contact number must have 9 digits.");
            }
        }

        private void IsValidateEmail(string email)
        {
            MailAddress.TryCreate(email, out var validMail);
            
            if(validMail is null)
            {
                throw new Exception("A valid e-mail must be informed.");
            }
        }
    }
}