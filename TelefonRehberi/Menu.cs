using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Menu
    {
        private readonly IMenuService _menuService;

        public Menu(IMenuService menuService)
        {
            _menuService = menuService;
        }

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
                    FindPerson("KİŞİ ARA");
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
            ToMenu(_menuService.ListBlocked());
        }

        public void BlockPerson(string v)
        {
            Header(v);
            ToMenu(_menuService.BlockPerson());
        }

        public void ListQuickCalls(string v)
        {
            Header(v);
            ToMenu(_menuService.ListQuickCalls());
        }

        public void AddToQuickCall(string v)
        {
            Header(v);
            ToMenu(_menuService.AddToQuickCall());
        }

        public void RemovePerson(string v)
        {
            Header(v);
            ToMenu(_menuService.RemovePerson());
        }

        public void FindPerson(string v)
        {
            Header(v);
            ToMenu(_menuService.FindPerson());
        }

        public void ListPerson(string v)
        {
            Header(v);
            ToMenu(_menuService.ListPerson());
        }

        public void AddPerson(string v)
        {
            Header(v);
            ToMenu(_menuService.AddPerson());
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
            Console.WriteLine(new string('-', v.Length));
            Console.WriteLine();
        }


    }
}
