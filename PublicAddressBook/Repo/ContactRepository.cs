using Microsoft.EntityFrameworkCore;
using PublicAddressBook.Data;
using PublicAddressBook.Data.Models;
using PublicAddressBook.Repo.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAddressBook.Repo
{
    public class ContactRepository : IContactRepository
    {
        public ApplicationDbContext _dbContext { get; set; }
        public ContactRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        #region CONTACT
        public Contact GetContact(int id)
        {
            return _dbContext.Contacts
                .Include(x => x.PhoneNumbers)
                .FirstOrDefault(x => x.Id == id);
        }
        public List<Contact> GetAllContacts()
        {
            return _dbContext.Contacts
                .Include(x => x.PhoneNumbers)
                .ToList();
        }
        public Contact AddContact(Contact model)
        {
            var entity =_dbContext.Contacts.Add(model).Entity;
            _dbContext.SaveChanges();
            return entity;
        }
        public void DeleteContact(int id)
        {
            var contact = _dbContext.Contacts.Find(id);
            if (contact != null)
            {
                _dbContext.Contacts.Remove(contact);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateContact(Contact model)
        {
            if (model != null)
            {
                _dbContext.Contacts.Update(model);
                _dbContext.SaveChanges();
            }
        }
        #endregion

        #region PHONE_NUMBER
        public void AddPhoneNumber(PhoneNumber model)
        {
            if (model != null)
            {
                _dbContext.PhoneNumbers.Update(model);
                _dbContext.SaveChanges();
            }
        }
        public void DeletePhoneNumber(int id)
        {
            var phoneNumber = _dbContext.PhoneNumbers.Find(id);
            if (phoneNumber != null)
            {
                _dbContext.PhoneNumbers.Remove(phoneNumber);
                _dbContext.SaveChanges();
            }
        }


        #endregion
    }
}
