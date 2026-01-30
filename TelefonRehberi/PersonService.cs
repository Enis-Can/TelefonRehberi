using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class PersonService
    {
        private readonly List<Person> persons = new();
        private IEnumerable<Person> QuickCalls => persons.Where(p => p.IsQuickCall);
        private IEnumerable<Person> BlockedPersons => persons.Where(p => p.IsBlocked);

        public IReadOnlyList<Person> GetBlockedPersons()
        {
            return BlockedPersons.ToList();
        }
        public IReadOnlyList<Person> GetQuickCalls()
        {
            return QuickCalls.ToList();
        }
        public IReadOnlyList<Person> GetAllPersons()
        {
            return persons.AsReadOnly();
        }
        public void AddPerson(Person person)
        {
            persons.Add(person);
        }
        public void DeletePerson(Person person)
        {
            persons.Remove(person);
        }
        public Person GetPerson(int index)
        {
            return persons[index];
        }
        public bool HasPersons()
        {
            return persons.Any();
        }
        public bool HasQuickCalls()
        {
            return QuickCalls.Any();
        }
        public bool HasBlockedPersons()
        {
            return BlockedPersons.Any();

        }

        public List<Person> FindPerson(string searchTerm)
        {
            var filteredPersons = persons.Where(x => x.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || x.PhoneNumber.Contains(searchTerm)).ToList();
            return filteredPersons;
        }
    }
}
