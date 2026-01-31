using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class MenuService : IMenuService
    {
        private readonly IPersonService _service;

        public MenuService(IPersonService service)
        {
            _service = service;
        }


        public string ListBlocked()
        {
            if (_service.HasBlockedPersons())
            {
                var blockedCount = ListPersons(_service.GetBlockedPersons());
                return string.Format("{0} adet engelli kişi listelendi.", blockedCount);
            }
            return "Engelli listesinde kayıtlı kişi bulunmamaktadır.";
        }

        public string BlockPerson()
        {
            if (_service.HasPersons())
            {
                var personCount = ListPersons(_service.GetAllPersons());
                int index = Getter.GetInt("Engellemek istediğiniz kişinin numarasını giriniz: ", 1, personCount) - 1;
                var personToBlock = _service.GetPerson(index);
                if (personToBlock.IsBlocked)
                {
                    Console.WriteLine("Seçilen kişi zaten engellenenler listesinde bulunmaktadır.");
                    ConsoleKey validation = Getter.GetConsoleKey($"{personToBlock.FullName} adlı kişinin engelini kaldırmak ister misiniz?(e/h) ", ConsoleKey.E, ConsoleKey.H);
                    if (validation == ConsoleKey.E)
                    {
                        personToBlock.UnblockPerson();
                        return "Kişi engelli listesinden başarıyla çıkarıldı.";
                    }
                    else return "Kişi engelli listesinden çıkarma işlemi iptal edildi.";
                }
                else
                {
                    ConsoleKey validation = Getter.GetConsoleKey($"{personToBlock.FullName} adlı kişiyi engelli listesine eklemek istediğinize emin misiniz?(e/h) ", ConsoleKey.E, ConsoleKey.H);
                    if (validation == ConsoleKey.E)
                    {
                        personToBlock.BlockPerson();
                        return "Kişi engelli listesine başarıyla eklendi.";
                    }
                    else return "Kişi engelli listesine ekleme işlemi iptal edildi.";
                }
            }
            else return "Rehberde kayıtlı kişi bulunmamaktadır.";
        }

        public string ListQuickCalls()
        {
            if (_service.HasQuickCalls())
            {
                var quickCallsCount = ListPersons(_service.GetQuickCalls());
                return string.Format("{0} adet hızlı arama listelendi.", quickCallsCount);
            }
            else return "Hızlı arama listesinde kayıtlı kişi bulunmamaktadır.";
        }

        public string AddToQuickCall()
        {
            if (_service.HasPersons())
            {
                var personsCount = ListPersons(_service.GetAllPersons());
                int index = Getter.GetInt("Hızlı aramaya eklemek istediğiniz kişinin numarasını giriniz: ", 1, personsCount) - 1;
                var personToAdd = _service.GetPerson(index);
                if (personToAdd.IsQuickCall)
                {
                    Console.WriteLine("Seçilen kişi zaten hızlı arama listesinde bulunmaktadır.");
                    ConsoleKey validation = Getter.GetConsoleKey($"{personToAdd.FullName} adlı kişiyi hızlı arama listesinden çıkartmak ister misiniz?(e/h) ", ConsoleKey.E, ConsoleKey.H);
                    if (validation == ConsoleKey.E)
                    {
                        personToAdd.RemoveQuickCall();
                        return "Kişi hızlı arama listesinden başarıyla çıkarıldı.";
                    }
                    else return "Kişi hızlı arama listesinden çıkarma işlemi iptal edildi.";
                }
                else
                {
                    ConsoleKey validation = Getter.GetConsoleKey($"{personToAdd.FullName} adlı kişiyi hızlı arama listesine eklemek istediğinize emin misiniz?(e/h) ", ConsoleKey.E, ConsoleKey.H);
                    if (validation == ConsoleKey.E)
                    {
                        personToAdd.AddQuickCall();
                        return"Kişi hızlı arama listesine başarıyla eklendi.";
                    }
                    else return "Kişi hızlı arama listesine ekleme işlemi iptal edildi.";
                }
            }
            else return "Rehberde kayıtlı kişi bulunmamaktadır.";
        }

        public string RemovePerson()
        {
            if (_service.HasPersons())
            {
                var personsCount = ListPersons(_service.GetAllPersons());
                int index = Getter.GetInt("Silinecek kişinin numarasını giriniz: ", 1, personsCount) - 1;
                var personToRemove = _service.GetPerson(index);
                ConsoleKey validation = Getter.GetConsoleKey($"{personToRemove.FullName} adlı kişiyi silmek istediğinize emin misiniz?(e/h) ", ConsoleKey.E, ConsoleKey.H);
                if (validation == ConsoleKey.E)
                {
                    _service.DeletePerson(personToRemove);
                    return "Kişi rehberden başarıyla silindi.";
                }
                else return "Kişi silme işlemi iptal edildi.";
            }
            else return "Rehberde kayıtlı kişi bulunmamaktadır.";
        }

        public string FindPerson()
        {
            if (_service.HasPersons())
            {
                var filteredPersons = _service.FindPerson(Getter.GetString("Aramak istediğiniz kişinin adı veya numarası: "));
                if (filteredPersons.Any())
                {
                    ListPersons(filteredPersons);
                    return string.Format("{0} adet kişi bulundu.", filteredPersons.Count);
                }
                else return "Arama kriterlerine uygun kişi bulunamadı.";
            }
            else return "Rehberde kayıtlı kişi bulunmamaktadır.";
        }

        public string ListPerson()
        {
            if (_service.HasPersons())
            {
                var personsCount = ListPersons(_service.GetAllPersons());
                return string.Format("{0} adet kişi listelendi.", personsCount);
            }
            else return "Rehberde kayıtlı kişi bulunmamaktadır.";
        }

        public string AddPerson()
        {
            Console.WriteLine("Kişinin; ");
            var person = new Person(
                Getter.GetString("Adı: "),
                Getter.GetString("Soyadı: "),
                Getter.GetPhoneNumber("Telefon Numarası: "));
            if(!_service.AddPerson(person))
            {
                return "Bu telefon numarası rehberde kayıtlı bulunmaktadır.";
            }
            return "Kişi rehbere başarıyla eklendi.";
        }

        private int ListPersons(IEnumerable<Person> persons)
        {
            int order = 0;
            foreach (var person in persons)
            {
                order++;
                Console.WriteLine($"{order}- {person.PrintFormat()}");
            }
            return order;
        }
    }
}
