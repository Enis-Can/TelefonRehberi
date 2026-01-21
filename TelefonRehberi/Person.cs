using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string FullName { get { return Name + " " + Surname; } }
        public bool isQuickCall { get; set; }
        public bool isBlocked { get; set; }
        public void Print(int order)
        {
            Console.WriteLine("{0}- {1} : {2}",order,FullName,PhoneNumber);
        }
    }
}
