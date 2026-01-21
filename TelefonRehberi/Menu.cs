using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Menu
    {
        static List<Person> Persons = new();
        static List<Person> QuickCalls => Persons.Where(p => p.isQuickCall).ToList();
        static List<Person> BlockedPersons => Persons.Where(p => p.isBlocked).ToList();
        internal static void MenuOptions(ConsoleKey key)
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

        private static void ListBlocked(string v)
        {
            Header(v);
            if(BlockedPersons.Any())
            {
                Lister.ListPersons(BlockedPersons);
                ToMenu(string.Format("{0} adet engelli kişi listelendi.", BlockedPersons.Count));
            }
            else ToMenu("Engelli listesinde kayıtlı kişi bulunmamaktadır.");
        }

        private static void BlockPerson(string v)
        {
            Header(v);
            if (Persons.Any())
            {
                Lister.ListPersons(Persons);
                int index = Getter.GetInt("Engellemek istediğiniz kişinin numarasını giriniz: ", 1, Persons.Count) - 1;
                var personToBlock = Persons[index];
                if(personToBlock.isBlocked)
                {
                    Console.WriteLine("Seçilen kişi zaten engellenenler listesinde bulunmaktadır.");
                    Console.Write("{0} adlı kişinin engelini kaldırmak ister misiniz?(e) ", personToBlock.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToBlock.isBlocked = false;
                        ToMenu("Kişi engelli listesinden başarıyla çıkarıldı.");
                    }
                    else ToMenu("Kişi engelli listesinden çıkarma işlemi iptal edildi.");
                }
                else
                {
                    Console.Write("{0} adlı kişiyi engelli listesine eklemek istediğinize emin misiniz?(e) ", personToBlock.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToBlock.isBlocked = true;
                        ToMenu("Kişi engelli listesine başarıyla eklendi.");
                    }
                    else ToMenu("Kişi engelli listesine ekleme işlemi iptal edildi.");
                }
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        private static void ListQuickCalls(string v)
        {
            Header(v);
            if(QuickCalls.Any())
            {
                Lister.ListPersons(QuickCalls);
                ToMenu(string.Format("{0} adet hızlı arama listelendi.", QuickCalls.Count));
            }
            else ToMenu("Hızlı arama listesinde kayıtlı kişi bulunmamaktadır.");
        }

        private static void AddToQuickCall(string v)
        {
            Header(v);
            if (Persons.Any())
            {
                Lister.ListPersons(Persons);
                int index = Getter.GetInt("Hızlı aramaya eklemek istediğiniz kişinin numarasını giriniz: ", 1, Persons.Count) - 1;
                var personToAdd = Persons[index];
                if (personToAdd.isQuickCall)
                {
                    Console.WriteLine("Seçilen kişi zaten hızlı arama listesinde bulunmaktadır.");
                    Console.Write("{0} adlı kişiyi hızlı arama listesinden çıkartmak ister misiniz?(e) ", personToAdd.FullName);
                    if(Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToAdd.isQuickCall = false;
                        ToMenu("Kişi hızlı arama listesinden başarıyla çıkarıldı.");
                    }
                    else ToMenu("Kişi hızlı arama listesinden çıkarma işlemi iptal edildi.");
                }
                else {
                    Console.Write("{0} adlı kişiyi hızlı arama listesine eklemek istediğinize emin misiniz?(e) ", personToAdd.FullName);
                    if (Console.ReadKey().Key == ConsoleKey.E)
                    {
                        personToAdd.isQuickCall = true;
                        ToMenu("Kişi hızlı arama listesine başarıyla eklendi.");
                    }
                else ToMenu("Kişi hızlı arama listesine ekleme işlemi iptal edildi.");
                }
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        private static void RemovePerson(string v)
        {
            Header(v);
            if (Persons.Any())
            {
                Lister.ListPersons(Persons);
                int index = Getter.GetInt("Silinecek kişinin numarasını giriniz: ", 1, Persons.Count) - 1;
                var personToRemove = Persons[index];
                Console.Write("{0} adlı kişiyi silmek istediğinize emin misiniz?(e) ", personToRemove.FullName);
                if(Console.ReadKey().Key==ConsoleKey.E)
                {
                    Persons.RemoveAt(index);
                    ToMenu("Kişi rehberden başarıyla silindi.");
                }
                else ToMenu("Kişi silme işlemi iptal edildi.");
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        private static void FindPerson(string v)
        {
            Header(v);
            if (Persons.Any())
            {
                var filteredPersons = PersonFinder.FindPerson(Persons);
                if (filteredPersons.Any())
                {
                    Lister.ListPersons(filteredPersons);
                    ToMenu(string.Format("{0} adet kişi bulundu.", filteredPersons.Count));
                }
                else ToMenu("Arama kriterlerine uygun kişi bulunamadı.");
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        private static void ListPerson(string v)
        {
            Header(v);
            if (Persons.Any())
            {
                Lister.ListPersons(Persons);
                ToMenu(string.Format("{0} adet kişi listelendi.",Persons.Count));
            }
            else ToMenu("Rehberde kayıtlı kişi bulunmamaktadır.");
        }

        private static void AddPerson(string v)
        {
            Header(v);
            Console.WriteLine("Kişinin; ");
            var person = new Person()
            {
                Name = Getter.GetString("Adı: "),
                Surname = Getter.GetString("Soyadı: "),
                PhoneNumber = Getter.GetString("Telefon Numarası: ")
            };
            Persons.Add(person);
            ToMenu("Kişi rehbere başarıyla eklendi.");

        }

        private static void ToMenu(string v)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Menüye devam etmek için herhangi bir tuşa basınız.");
            Console.ReadKey();
        }

        private static void Header(string v)
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
