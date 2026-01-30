using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Lister
    {
        internal static int ListPersons(List<Person> persons)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine($"{i}- " + persons[i].ToPrint());
            }
            return persons.Count;
        }

        internal static int ListPersons(IEnumerable<Person> persons)
        {
            int order = 0;
            foreach (var person in persons)
            {
                order++;
                Console.WriteLine($"{order}- " + person.ToPrint());
            }
            return order;
        }
    }
}
