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
        public PhoneNumber PhoneNumber { get; }
        public string FullName => $"{Name} {Surname}";
        public bool IsQuickCall { get; private set; } = false;
        public bool IsBlocked { get; private set; } = false;
        public string PrintFormat()
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
            PhoneNumber = new(phoneNumber);
        }
        public void AddQuickCall()
        {
            IsQuickCall = true;
        }
        public void RemoveQuickCall()
        {
            IsQuickCall = false;
        }

        public void BlockPerson()
        {
            IsBlocked = true;
        }
        public void UnblockPerson()
        {
            IsBlocked = false;
        }
    }
}
