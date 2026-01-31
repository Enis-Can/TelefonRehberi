using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal interface IPersonService
    {
        public IReadOnlyList<Person> GetBlockedPersons();
        public IReadOnlyList<Person> GetQuickCalls();
        public IReadOnlyList<Person> GetAllPersons();
        public bool AddPerson(Person person);
        public void DeletePerson(Person person);
        public Person GetPerson(int index);
        public bool HasPersons();
        public bool HasQuickCalls();
        public bool HasBlockedPersons();
        public bool PhoneNumberExists(string phoneNumber);
        public IReadOnlyList<Person> FindPerson(string searchTerm);
    }
}
