using PublicAddressBook.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAddressBook.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        [Display(Name = "Phone Number")]
        public List<string> PhoneNumbers { get; set; } = new List<string>();

        public ContactViewModel()
        {

        }
        public ContactViewModel(Contact model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Address = model.Address;
            this.DateOfBirth = model.DateOfBirth.ToString("dd.MM.yyyy");
            if (model.PhoneNumbers.Any())
            {
                foreach (var num in model.PhoneNumbers)
                {
                    this.PhoneNumbers.Add(num.Number);
                }

            }
        }

    }
    public static class ContactExtensions
    {
        public static Contact MapToContactModel(this ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                DateOfBirth = DateTime.Parse(model.DateOfBirth)                
            };
        }
    }
        
}
