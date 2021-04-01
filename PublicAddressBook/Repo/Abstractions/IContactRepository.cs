using PublicAddressBook.Data.Models;
using System.Collections.Generic;

namespace PublicAddressBook.Repo.Abstractions
{
    public interface IContactRepository
    {
        void AddPhoneNumber(PhoneNumber model);
        Contact AddContact(Contact model);
        void DeleteContact(int id);
        void DeletePhoneNumber(int id);
        List<Contact> GetAllContacts();
        Contact GetContact(int id);
        void UpdateContact(Contact model);
    }
}