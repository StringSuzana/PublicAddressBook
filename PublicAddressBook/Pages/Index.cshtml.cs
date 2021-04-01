using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PublicAddressBook.Services;
using PublicAddressBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAddressBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IContactService _service;
        public List<ContactViewModel> Contacts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IContactService serv)
        {
            _logger = logger;
            _service = serv;
        }

        public void OnGet()
        {
            Contacts = _service.GetAllContacts();
        }
    }
}
