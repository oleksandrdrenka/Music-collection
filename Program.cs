using System;
using System.Text;

namespace MusicCollection
{
    internal class Program
    {
        const int Capacity = 100;

        static int[] ids = new int[Capacity];
        static string[] artists = new string[Capacity];
        static string[] titles = new string[Capacity];
        static string[] albums = new string[Capacity];
        static int[] years = new int[Capacity];
        static int[] durations = new int[Capacity];
        static int[] genreIds = new int[Capacity];
        static int[] plays = new int[Capacity];
        static int count = 0;
        static int nextId = 1;

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
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10": ShowInDevelopment(); Pause(); break;
                    case "11": ShowAbout(); Pause(); break;
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
            Console.WriteLine("1 — Показати всі треки");
            Console.WriteLine("2 — Додати трек");
            Console.WriteLine("3 — Знайти за умовою");
            Console.WriteLine("4 — Змінити трек");
            Console.WriteLine("5 — Видалити трек");
            Console.WriteLine("6 — Зведена таблиця");
            Console.WriteLine("7 — Зберегти у файл");
            Console.WriteLine("8 — Завантажити з файлу");
            Console.WriteLine("9 — Експорт у CSV");
            Console.WriteLine("10 — Заповнити тестовими даними");
            Console.WriteLine("11 — Про програму");
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
            Console.WriteLine("Поки не зроблено.");
        }

        static void ShowInvalidChoice()
        {
            Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
        }

        static void ShowAbout()
        {
            Console.WriteLine("=== Про застосунок ===");
            Console.WriteLine("Тема №7: Музична колекція");
            Console.WriteLine("Головна сутність: Трек (8 полів)");
            Console.WriteLine("1. Код (int)");
            Console.WriteLine("2. Виконавець (string)");
            Console.WriteLine("3. Назва треку (string)");
            Console.WriteLine("4. Альбом (string)");
            Console.WriteLine("5. Рік випуску (int)");
            Console.WriteLine("6. Тривалість у секундах (int)");
            Console.WriteLine("7. Код жанру (int)");
            Console.WriteLine("8. Кількість прослуховувань (int)");
            Console.WriteLine($"Місткість сховища: {Capacity}. Зайнято: {count}.");
        }

        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"Помилка: введіть ціле число від {min} до {max}.");
            }
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"Помилка: введіть число від {min} до {max}.");
            }
        }
    }
}