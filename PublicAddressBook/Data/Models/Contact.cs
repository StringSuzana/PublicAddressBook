using PublicAddressBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAddressBook.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }//unique 1.
        public string Address { get; set; }//unique 2.
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }//Lazy
    }

}
