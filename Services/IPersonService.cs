using dotnet_zadanie5.Models;
using System.Security.Claims;

namespace dotnet_zadanie5.Services
{
    public interface IPersonService
    {
        public void AddEntry(Person person);
        public void AddEntry(ClaimsPrincipal user,Person person);
        public IQueryable<Person> GetAllEntries();
        public IQueryable<Person> GetEntriesFromToday();
    }
}
