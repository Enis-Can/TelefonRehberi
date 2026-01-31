using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class PhoneNumber
    {
        public string Plus { get; }
        public string Number { get; }
        public string FullNumber => $"{Plus}{Number}";
        public PhoneNumber(string rawNumber)
        {
            if (rawNumber.StartsWith("+"))
            {
                Plus = "+";
                Number = rawNumber.Substring(1);
            }
            else
            {
                Plus = string.Empty;
                Number = rawNumber;
            }
        }
        public override string ToString()
        {
            return FullNumber;
        }
    }
}
