using dotnet_zadanie5.Data;
using dotnet_zadanie5.Models;
using System.Security.Claims;

namespace dotnet_zadanie5.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;
        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEntry(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void AddEntry(ClaimsPrincipal currentUser, Person Person)
        {
            Person.NameLastname = Person.Name + " " + Person.LastName;
            Person.IsLeap();
            DateTime date = DateTime.Now;
            Person.Date = date;

            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            Person.UserId = currentUserID.ToString();

            _context.Person.Add(Person);
            _context.SaveChanges();

        }

        public IQueryable<Person> GetAllEntries()
        {
            return _context.Person;
        }

        public IQueryable<Person> GetEntriesFromToday()
        {
            DateTime now = DateTime.Now;
            return GetAllEntries().Where(p => p.Date.Day == now.Day && p.Date.Month == now.Month && p.Date.Year == now.Year);
            //return GetAllEntries().Where(p => p.IsSameDate(p.Date, DateTime.Today) == true);
            //return GetAllEntries().Where(p => p.Date == DateTime.Today);
        }

    }
}
