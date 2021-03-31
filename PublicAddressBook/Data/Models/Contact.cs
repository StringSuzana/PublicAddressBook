using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAddressBook.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }//
        public string LastName { get; set; }//
        public string Address { get; set; }//
        public DateTime DateOfBirth { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
