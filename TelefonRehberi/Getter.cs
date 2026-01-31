using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Getter
    {
        public static string GetString(string msg, int min = 0, int max = int.MaxValue)
        {
            string? txt = string.Empty;
            bool err = false;
            do
            {
                Console.Write(msg);
                txt = Console.ReadLine();
                if (string.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Boş değer girilemez");
                    err = true;
                }
                else if (txt.Length > max || txt.Length < min)
                {
                    Console.WriteLine("Minimum {0}, maksimum {1} karakter giriniz.", min, max);
                    err = true;
                }
                else err = false;
            }
            while (err);
            return txt;
        }

        public static int GetInt(string msg, int min = int.MinValue, int max = int.MaxValue)
        {
            int val = 0;
            bool err = false;
            do
            {
                Console.Write(msg);
                if (!int.TryParse(Console.ReadLine(), out val))
                {
                    Console.WriteLine("Geçerli bir tam sayı giriniz.");
                    err = true;
                }
                else if (val > max || val < min)
                {
                    Console.WriteLine("Minimum {0}, maksimum {1} arasında bir değer giriniz.", min, max);
                    err = true;
                }
                else err = false;
            }
            while (err);
            return val;
        }

        public static double GetDouble(string msg, double min = double.MinValue, double max = double.MaxValue)
        {
            double val = 0;
            bool err = false;
            do
            {
                Console.Write(msg);
                if (!double.TryParse(Console.ReadLine(),NumberStyles.Any, CultureInfo.CurrentCulture, out val))
                {
                    Console.WriteLine("Geçerli bir sayı giriniz.");
                    err = true;
                }
                else if (val > max || val < min)
                {
                    Console.WriteLine("Minimum {0}, maksimum {1} arasında bir değer giriniz.", min, max);
                    err = true;
                }
                else err = false;
            }
            while (err);
            return val;
        }

        public static decimal GetDecimal(string msg, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            decimal val = 0;
            bool err = false;
            do
            {
                Console.Write(msg);
                if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.CurrentCulture, out val))
                {
                    Console.WriteLine("Geçerli bir fiyat giriniz.");
                    err = true;
                }
                else if (val > max || val < min)
                {
                    Console.WriteLine("Minimum {0}, maksimum {1} arasında bir değer giriniz.", min, max);
                    err = true;
                }
                else err = false;
            } while (err);
            return val;
        }

        public static DateTime GetDateTime(string msg, DateTime min, DateTime max)
        {
            DateTime date = DateTime.MinValue;
            bool err = false;
            do
            {
                Console.Write(msg);
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Geçerli bir tarih giriniz.");
                    err = true;
                }
                else if (date > max || date < min)
                {
                    Console.WriteLine("Minimum {0}, maksimum {1} tarihleri arasında bir değer giriniz.",
                        min.ToString("dd MMMM yyyy"),
                        max.ToString("dd MMMM yyyy"));
                    err = true;
                }
                else err = false;
            }
            while (err);
            return date;
        }

        public static string GetPhoneNumber(string msg)
        {
            string? txt = string.Empty;
            bool err = false;
            do
            {
                Console.Write(msg);
                txt = Console.ReadLine();
                if (string.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Boş değer girilemez");
                    err = true;
                }
                else
                {
                    string number;
                    if (txt.StartsWith("+")) number = txt.Substring(1);
                    else number = txt;

                    if (txt.Length < 10 || txt.Length > 15) 
                    {
                        Console.WriteLine("Telefon numarası en az 10, en fazla 15 karakter olmalıdır.");
                        err = true;
                    }
                    else if (!number.All(char.IsDigit))
                    {
                        Console.WriteLine("Geçerli bir telefon numarası giriniz.");
                        err = true;
                    }
                    else err = false;
                }
            }
            while (err);
            return txt;
        }

        public static ConsoleKey GetConsoleKey(string msg, params ConsoleKey[] validKeys)
        {
            ConsoleKey key;
            bool err = false;
            do
            {
                Console.Write(msg);
                key = Console.ReadKey().Key;
                if (!validKeys.Contains(key))
                {
                    Console.WriteLine();
                    Console.WriteLine("Hatalı bir tuşlama yaptınız.");
                    err = true;
                }
                else err = false;
            }
            while (err);
            return key;
        }
    }
}