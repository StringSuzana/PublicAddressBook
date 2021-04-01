using PublicAddressBook.Data.Models;
using PublicAddressBook.Repo.Abstractions;
using PublicAddressBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAddressBook.Services
{
    public class ContactService : IContactService
    {
        public IContactRepository _repo { get; set; }
        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }
        public ContactViewModel GetContact(int id)
        {
            return new ContactViewModel(_repo.GetContact(id));
        }
        public List<ContactViewModel> GetAllContacts()
        {
            var result = new List<ContactViewModel>();
            var contacts = _repo.GetAllContacts();
            foreach (var contact in contacts)
            {
                result.Add(new ContactViewModel(contact));
            }
            return result;
        }
        public void CreateContact(ContactViewModel viewModel)
        {
            //create contact
            var contact = _repo.AddContact(viewModel.MapToContactModel());

            //create numbers
            viewModel.PhoneNumbers?.ForEach(num =>
            {
                _repo.AddPhoneNumber(PhoneNumber.Create(number: num, isActive: true, contact: contact));
            });
        }
        public void DeleteContact(int id)
        {
            _repo.DeleteContact(id);
        }
        public void UpdateContact(ContactViewModel viewModel)
        {
            //create contact
            var contact = _repo.AddContact(viewModel.MapToContactModel());

            //create numbers
            viewModel.PhoneNumbers.ForEach(num =>
            {
                _repo.AddPhoneNumber(PhoneNumber.Create(number: num, isActive: true, contact: contact));
            });
        }
    }
}
