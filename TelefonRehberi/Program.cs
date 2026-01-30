// TELEFON REHBERİ
// 1- Kişi Ekle
// 2- Kişileri Listele
// 3- Kişi Ara
// 4- Kişi Sil
// 5- Hızlı Aramaya Ekle
// 6- Hızlı Arama Listesi
// 7- Kişiyi Engelle
// 8- Engellenmiş Kişi Listesi
// 9- Programdan Çık

using TelefonRehberi;

ConsoleKey key;
PersonService personService = new();
MenuService menuService = new(personService);
Menu menu = new(menuService);

do
{
    Console.Clear();
    Console.WriteLine("1- Kişi Ekle");
    Console.WriteLine("2- Kişileri Listele");
    Console.WriteLine("3- Kişi Ara");
    Console.WriteLine("4- Kişi Sil");
    Console.WriteLine("5- Hızlı Aramaya Ekle");
    Console.WriteLine("6- Hızlı Arama Listesi");
    Console.WriteLine("7- Kişiyi Engelle");
    Console.WriteLine("8- Engellenmiş Kişi Listesi");
    Console.WriteLine("9- Programdan Çık");
    Console.Write("Bir işlem seçiniz: ");
    key = Console.ReadKey().Key;
    menu.MenuOptions(key);
}
while (key != ConsoleKey.D9 && key != ConsoleKey.NumPad9);

Console.WriteLine();
Console.WriteLine("Uygulamayı kullandığınız için teşekkürler.");
Console.WriteLine("Uygulamadan çıkmak için herhangi bir tuşa basınız.");
Console.ReadKey();