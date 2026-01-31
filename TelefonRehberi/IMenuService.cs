using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal interface IMenuService
    {
        string ListPerson();
        string FindPerson();
        string AddPerson();
        string RemovePerson();

        string ListBlocked();
        string BlockPerson();

        string ListQuickCalls();
        string AddToQuickCall();
    }
}
