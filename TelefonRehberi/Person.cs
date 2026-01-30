using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Person
    {
        public string Name { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }
        public string FullName => $"{Name} {Surname}";
        public bool IsQuickCall { get; private set; } = false;
        public bool IsBlocked { get; private set; } = false;
        public override string ToString()
        {
            string toPrint = $"{FullName} : {PhoneNumber}";
            if(IsBlocked) toPrint += " (ENGELLİ)";
            if(IsQuickCall) toPrint += " (HIZLI ARAMA)";
            return toPrint;
        }
        public Person(string name, string surname, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }
        public void ToggleQuickCall()
        {
            IsQuickCall = !IsQuickCall;
        }

        public void ToggleBlocked()
        {
            IsBlocked = !IsBlocked;
        }
    }
}
