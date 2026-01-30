using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class MenuService
    {
        private readonly PersonService _service;

        public MenuService(PersonService service)
        {
            _service = service;
        }


        public string ListBlocked()
        {
            if (_service.HasBlockedPersons())
            {
                var blockedCount = Lister.ListPersons(_service.GetBlockedPersons());
                return string.Format("{0} adet engelli kişi listelendi.", blockedCount);
            }
            return "Engelli listesinde kayıtlı kişi bulunmamaktadır.";
        }

        public string BlockPerson()
        {
            if (_service.HasPersons())
            {
                var personCount = Lister.ListPersons(_service.GetAllPersons());
                int index = Getter.GetInt("Engellemek istediğiniz kişinin numarasını giriniz: ", 1, personCount) - 1;
                var personToBlock = _service.GetPerson(index);
                if (personToBlock.IsBlocked)
                {
                    Console.WriteLine("Seçilen kişi zaten engellenenler listesinde bulunmaktadır.");
                    Console.Write("{0} adlı kişinin engelini kaldırmak ister misiniz?(e) ", personToBlock.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToBlock.ToggleBlocked();
                        return "Kişi engelli listesinden başarıyla çıkarıldı.";
                    }
                    else return "Kişi engelli listesinden çıkarma işlemi iptal edildi.";
                }
                else
                {
                    Console.Write("{0} adlı kişiyi engelli listesine eklemek istediğinize emin misiniz?(e) ", personToBlock.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToBlock.ToggleBlocked();
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
                var quickCallsCount = Lister.ListPersons(_service.GetQuickCalls());
                return string.Format("{0} adet hızlı arama listelendi.", quickCallsCount);
            }
            else return "Hızlı arama listesinde kayıtlı kişi bulunmamaktadır.";
        }

        public string AddToQuickCall()
        {
            if (_service.HasPersons())
            {
                var personsCount = Lister.ListPersons(_service.GetAllPersons());
                int index = Getter.GetInt("Hızlı aramaya eklemek istediğiniz kişinin numarasını giriniz: ", 1, personsCount) - 1;
                var personToAdd = _service.GetPerson(index);
                if (personToAdd.IsQuickCall)
                {
                    Console.WriteLine("Seçilen kişi zaten hızlı arama listesinde bulunmaktadır.");
                    Console.Write("{0} adlı kişiyi hızlı arama listesinden çıkartmak ister misiniz?(e) ", personToAdd.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToAdd.ToggleQuickCall();
                        return "Kişi hızlı arama listesinden başarıyla çıkarıldı.";
                    }
                    else return "Kişi hızlı arama listesinden çıkarma işlemi iptal edildi.";
                }
                else
                {
                    Console.Write("{0} adlı kişiyi hızlı arama listesine eklemek istediğinize emin misiniz?(e) ", personToAdd.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToAdd.ToggleQuickCall();
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
                var personsCount = Lister.ListPersons(_service.GetAllPersons());
                int index = Getter.GetInt("Silinecek kişinin numarasını giriniz: ", 1, personsCount) - 1;
                var personToRemove = _service.GetPerson(index);
                Console.Write("{0} adlı kişiyi silmek istediğinize emin misiniz?(e) ", personToRemove.FullName);
                if (Console.ReadKey().Key == ConsoleKey.E)
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
                    Lister.ListPersons(filteredPersons);
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
                var personsCount = Lister.ListPersons(_service.GetAllPersons());
                return string.Format("{0} adet kişi listelendi.", personsCount);
            }
            else return "Rehberde kayıtlı kişi bulunmamaktadır.";
        }

        public string AddPerson(string v)
        {
            Console.WriteLine("Kişinin; ");
            var person = new Person(
                Getter.GetString("Adı: "),
                Getter.GetString("Soyadı: "),
                Getter.GetPhoneNumber("Telefon Numarası: "));
            _service.AddPerson(person);
            return "Kişi rehbere başarıyla eklendi.";
        }
    }
}
