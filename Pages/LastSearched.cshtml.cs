using dotnet_zadanie5.Data;
using dotnet_zadanie5.Models;
using dotnet_zadanie5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_zadanie5.Pages
{
    [Authorize]
    public class LastSearched : PageModel
    {
        public Person Person { get; set; }
        private readonly ApplicationDbContext _context;
        public List<Person> Osoby = new List<Person>();
        private readonly IPersonService _personService;
        public IQueryable<Person> Records { get; set; }

        public LastSearched(ApplicationDbContext context, IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }
        public void OnGet()
        {
            Records = _personService.GetAllEntries();
        }
    }
}
