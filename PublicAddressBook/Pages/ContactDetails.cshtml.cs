using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicAddressBook.Data;
using PublicAddressBook.Data.Models;
using PublicAddressBook.Services;
using PublicAddressBook.ViewModels;

namespace PublicAddressBook.Pages
{
    public class ContactDetailsModel : PageModel
    {
        private readonly IContactService _service;
        public ContactDetailsModel(IContactService serv)
        {
            _service = serv;
        }

        [BindProperty]
        public ContactViewModel contactViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            contactViewModel = _service.GetContact(id.GetValueOrDefault());

            if (contactViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
