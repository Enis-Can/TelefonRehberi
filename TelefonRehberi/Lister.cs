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
        internal static void ListPersons(List<Person> persons)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                persons[i].Print(i + 1);
            }
        }
    }
}
