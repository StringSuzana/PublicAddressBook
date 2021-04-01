using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PublicAddressBook.Data;
using PublicAddressBook.Data.Models;
using PublicAddressBook.Services;
using PublicAddressBook.ViewModels;

namespace PublicAddressBook.Pages
{
    public class CreateContactModel : PageModel
    {
        private readonly IContactService _service;
        private readonly ILogger<CreateContactModel> _logger;

        public CreateContactModel(ILogger<CreateContactModel> logger, IContactService serv)
        {
            _service = serv;
            _logger = logger;

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactViewModel contactViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _service.CreateContact(contactViewModel);
                return RedirectToPage("./Index");

            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Information, e.Message);
                return Page();

            }
        }
    }
}
