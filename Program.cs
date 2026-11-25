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
                    case "1": PrintTracks(); Pause(); break;
                    case "2": AddTrack(); Pause(); break;
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9": ShowInDevelopment(); Pause(); break;
                    case "10": FillTestData(); Pause(); break;
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

        static void StoreTrack(string artist, string title, string album, int year, int duration, int genreId, int playCount)
        {
            ids[count] = nextId;
            artists[count] = artist;
            titles[count] = title;
            albums[count] = album;
            years[count] = year;
            durations[count] = duration;
            genreIds[count] = genreId;
            plays[count] = playCount;
            count++;
            nextId++;
        }

        static void AddTrack()
        {
            Console.WriteLine("=== Додавання треку ===");

            if (count == Capacity)
            {
                Console.WriteLine("Сховище заповнене, додати трек неможливо.");
                return;
            }

            string artist = ReadText("Виконавець: ");
            string title = ReadText("Назва треку: ");
            string album = ReadText("Альбом: ");
            int year = ReadInt($"Рік випуску (1900–{DateTime.Now.Year}): ", 1900, DateTime.Now.Year);
            int duration = ReadInt("Тривалість у секундах (1–7200): ", 1, 7200);
            int genreId = ReadInt("Код жанру (1–10): ", 1, 10);
            int playCount = ReadInt("Кількість прослуховувань (0–1000000000): ", 0, 1000000000);

            StoreTrack(artist, title, album, year, duration, genreId, playCount);

            Console.WriteLine($"Додано трек №{ids[count - 1]}.");
        }

        static void FillTestData()
        {
            Console.WriteLine("=== Заповнення тестовими даними ===");

            const int testCount = 6;

            if (count + testCount > Capacity)
            {
                Console.WriteLine($"Недостатньо місця: потрібно {testCount}, вільно {Capacity - count}.");
                return;
            }

            StoreTrack("Queen", "Bohemian Rhapsody", "A Night at the Opera", 1975, 354, 1, 1500000);
            StoreTrack("Океан Ельзи", "Обійми", "Земля", 2013, 255, 1, 820000);
            StoreTrack("The Beatles", "Yesterday", "Help!", 1965, 125, 2, 1200000);
            StoreTrack("Pink Floyd", "Time", "The Dark Side of the Moon", 1973, 413, 1, 640000);
            StoreTrack("Imagine Dragons", "Believer", "Evolve", 2017, 204, 2, 2100000);
            StoreTrack("Radiohead", "Creep", "Pablo Honey", 1993, 238, 1, 950000);

            Console.WriteLine($"Додано {testCount} тестових треків. Зайнято: {count} із {Capacity}.");
        }

        static int CalculateTotalDuration(int[] trackDurations, int trackCount)
        {
            int total = 0;

            for (int i = 0; i < trackCount; i++)
            {
                total += trackDurations[i];
            }

            return total;
        }

        static string FormatDuration(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = totalSeconds % 3600 / 60;
            int seconds = totalSeconds % 60;

            return $"{hours} год {minutes:D2} хв {seconds:D2} с";
        }

        static void PrintTracks()
        {
            Console.WriteLine("=== Усі треки ===");

            if (count == 0)
            {
                Console.WriteLine("Записів поки немає.");
                return;
            }

            Console.WriteLine($"{"№",4}{"Виконавець",-22}{"Назва",-26}{"Альбом",-22}{"Рік",6}{"Трив.",8}{"Жанр",6}{"Прослух.",12}");
            Console.WriteLine(new string('-', 106));

            for (int i = 0; i < count; i++)
            {
                string time = $"{durations[i] / 60}:{durations[i] % 60:D2}";
                Console.WriteLine($"{ids[i],4}{artists[i],-22}{titles[i],-26}{albums[i],-22}{years[i],6}{time,8}{genreIds[i],6}{plays[i],12}");
            }

            Console.WriteLine(new string('-', 106));
            Console.WriteLine($"Записів: {count}.");

            int totalSeconds = CalculateTotalDuration(durations, count);
            Console.WriteLine($"Загальна тривалість колекції: {FormatDuration(totalSeconds)} ({totalSeconds} с).");
        }

        static string ReadText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.Trim();
                    if (input.Length >= 2)
                    {
                        return input;
                    }
                }
                Console.WriteLine("Помилка: введіть текст не коротший за 2 символи.");
            }
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