using System;
using System.Text;

namespace MusicCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ShowAbout(); Pause(); break;
                    case "2": RunTabulation(); Pause(); break;
                    case "3": ShowTwoDimensionalTable(); Pause(); break;
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8": ShowInDevelopment(); Pause(); break;
                    case "0": running = false; break;
                    default: ShowInvalidChoice(); Pause(); break;
                }
            }

            Console.WriteLine("Роботу завершено. До побачення!");
        }

        static void ShowMenu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("        СИСТЕМА ОБЛІКУ «МУЗИЧНА КОЛЕКЦІЯ»        ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1 — Про програму та структуру сутності");
            Console.WriteLine("2 — Табулювання: розрахунок обсягу треку від часу");
            Console.WriteLine("3 — Зведена таблиця прослуховувань (два входи)");
            Console.WriteLine("4 — Розрахунок загальної тривалості плейлиста");
            Console.WriteLine("5 — Показати всі треки (буде пізніше)");
            Console.WriteLine("6 — Додати новий трек (буде пізніше)");
            Console.WriteLine("7 — Пошук треку (буде пізніше)");
            Console.WriteLine("8 — Зберегти / завантажити файл (буде пізніше)");
            Console.WriteLine("0 — Вихід");
            Console.WriteLine("==================================================");
            Console.Write("Ваш вибір: ");
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void ShowInDevelopment()
        {
            Console.WriteLine("Цей пункт ще в розробці (буде у наступних роботах).");
        }

        static void ShowInvalidChoice()
        {
            Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
        }

        static void ShowAbout()
        {
            Console.WriteLine("=== Про застосунок ===");
            Console.WriteLine("Тема №7: Музична колекція");
        }

        static void RunTabulation()
        {
            Console.WriteLine("Табулювання в процесі оновлення...");
        }

        static void ShowTwoDimensionalTable()
        {
            Console.WriteLine("Зведена таблиця в процесі оновлення...");
        }
    }
}