using PublicAddressBook.ViewModels;
using System.Collections.Generic;

namespace PublicAddressBook.Services
{
    public interface IContactService
    {
        void CreateContact(ContactViewModel viewModel);
        void DeleteContact(int id);
        List<ContactViewModel> GetAllContacts();
        ContactViewModel GetContact(int id);
        void UpdateContact(ContactViewModel viewModel);
    }
}