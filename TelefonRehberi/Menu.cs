using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Menu
    {
        private readonly PersonService _service = new();
        internal void MenuOptions(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AddPerson("KİŞİ EKLE");
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    ListPerson("KİŞİ LİSTELE");
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    FindPerson("Kişi ARA");
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    RemovePerson("KİŞİ SİL");
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    AddToQuickCall("HIZLI ARAMAYA EKLE");
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    ListQuickCalls("HIZLI ARAMALARI LİSTELE");
                    break;
                case ConsoleKey.NumPad7:
                case ConsoleKey.D7:
                    BlockPerson("KİŞİYİ ENGELLE");
                    break;
                case ConsoleKey.NumPad8:
                case ConsoleKey.D8:
                    ListBlocked("ENGELLİ KİŞİ LİSTESİ");
                    break;
            }
        }

        public void ListBlocked(string v)
        {
            Header(v);
            if (_service.HasBlockedPersons())
            {
                var blockedCount = Lister.ListPersons(_service.GetBlockedPersons());
                ToMenu(string.Format("{0} adet engelli kişi listelendi.", blockedCount));
            }
            else ToMenu("Engelli listesinde kayıtlı kişi bulunmamaktadır.");
        }

        public void BlockPerson(string v)
        {
            Header(v);
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
                        ToMenu("Kişi engelli listesinden başarıyla çıkarıldı.");
                    }
                    else ToMenu("Kişi engelli listesinden çıkarma işlemi iptal edildi.");
                }
                else
                {
                    Console.Write("{0} adlı kişiyi engelli listesine eklemek istediğinize emin misiniz?(e) ", personToBlock.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToBlock.ToggleBlocked();
                        ToMenu("Kişi engelli listesine başarıyla eklendi.");
                    }
                    else ToMenu("Kişi engelli listesine ekleme işlemi iptal edildi.");
                }
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        public void ListQuickCalls(string v)
        {
            Header(v);
            if (_service.HasQuickCalls())
            {
                var quickCallsCount = Lister.ListPersons(_service.GetQuickCalls());
                ToMenu(string.Format("{0} adet hızlı arama listelendi.", quickCallsCount));
            }
            else ToMenu("Hızlı arama listesinde kayıtlı kişi bulunmamaktadır.");
        }

        public void AddToQuickCall(string v)
        {
            Header(v);
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
                        ToMenu("Kişi hızlı arama listesinden başarıyla çıkarıldı.");
                    }
                    else ToMenu("Kişi hızlı arama listesinden çıkarma işlemi iptal edildi.");
                }
                else
                {
                    Console.Write("{0} adlı kişiyi hızlı arama listesine eklemek istediğinize emin misiniz?(e) ", personToAdd.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToAdd.ToggleQuickCall();
                        ToMenu("Kişi hızlı arama listesine başarıyla eklendi.");
                    }
                    else ToMenu("Kişi hızlı arama listesine ekleme işlemi iptal edildi.");
                }
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        public void RemovePerson(string v)
        {
            Header(v);
            if (_service.HasPersons())
            {
                var personsCount = Lister.ListPersons(_service.GetAllPersons());
                int index = Getter.GetInt("Silinecek kişinin numarasını giriniz: ", 1, personsCount) - 1;
                var personToRemove = _service.GetPerson(index);
                Console.Write("{0} adlı kişiyi silmek istediğinize emin misiniz?(e) ", personToRemove.FullName);
                if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    _service.DeletePerson(personToRemove);
                    ToMenu("Kişi rehberden başarıyla silindi.");
                }
                else ToMenu("Kişi silme işlemi iptal edildi.");
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        public void FindPerson(string v)
        {
            Header(v);
            if (_service.HasPersons())
            {
                var filteredPersons = _service.FindPerson(Getter.GetString("Aramak istediğiniz kişinin adı veya numarası: ").Replace(" ", "").ToLowerInvariant());
                if (filteredPersons.Any())
                {
                    Lister.ListPersons(filteredPersons);
                    ToMenu(string.Format("{0} adet kişi bulundu.", filteredPersons.Count));
                }
                else ToMenu("Arama kriterlerine uygun kişi bulunamadı.");
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        public void ListPerson(string v)
        {
            Header(v);
            if (_service.HasPersons())
            {
                var personsCount = Lister.ListPersons(_service.GetAllPersons());
                ToMenu(string.Format("{0} adet kişi listelendi.", personsCount));
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        public void AddPerson(string v)
        {
            Header(v);
            Console.WriteLine("Kişinin; ");
            var person = new Person(
                Getter.GetString("Adı: "),
                Getter.GetString("Soyadı: "),
                Getter.GetPhoneNumber("Telefon Numarası: "));
            _service.AddPerson(person);
            ToMenu("Kişi rehbere başarıyla eklendi.");

        }

        private void ToMenu(string v)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Menüye devam etmek için herhangi bir tuşa basınız.");
            Console.ReadKey();
        }

        private void Header(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }


    }
}
