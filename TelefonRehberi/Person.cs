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
        public string FullName => string.Format("{0} {1}", Name, Surname);
        public bool IsQuickCall { get; private set; } = false;
        public bool IsBlocked { get; private set; } = false;
        public string ToPrint()
        {
            string toPrint = string.Format("{0} : {1}",FullName,PhoneNumber);
            if(IsBlocked) toPrint += " (ENGELLİ)";
            if(IsQuickCall) toPrint += " (HIZLI ARAMA)";
            toPrint += Environment.NewLine;
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
