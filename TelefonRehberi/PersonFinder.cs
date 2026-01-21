using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class PersonFinder
    {
        public static List<Person> FindPerson(List<Person> persons)
        {
            string searchTerm = Getter.GetString("Aramak istediğiniz kişinin adı veya numarası: ").Replace(" ","").ToLower();
            var filteredPersons = persons.Where(p => p.FullName.Replace(" ","").ToLower().Contains(searchTerm) || p.PhoneNumber.Contains(searchTerm)).ToList();
            return filteredPersons;
        }
    }
}
