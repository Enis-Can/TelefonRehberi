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
        internal static int ListPersons(IEnumerable<Person> persons)
        {
            int order = 0;
            foreach (var person in persons)
            {
                order++;
                Console.WriteLine($"{order}- " + person.ToString());
            }
            return order;
        }
    }
}
