using dotnet_zadanie5.Data;
using dotnet_zadanie5.Models;
using dotnet_zadanie5.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Claims;

namespace dotnet_zadanie5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Person Person { get; set; }
        public List<Person> People = new List<Person>();
        private readonly ApplicationDbContext _context;
        private readonly IPersonService _personService;
        public IQueryable<Person> Records { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, IPersonService personService)
        {
            _logger = logger;
            _context = context;
            _personService = personService;
        }

        public void OnGet()
        {
            Records = _personService.GetEntriesFromToday();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ClaimsPrincipal currentUser = this.User;
            _personService.AddEntry(currentUser, Person);
            Records = _personService.GetEntriesFromToday();
            return Page();
        }
    }

}