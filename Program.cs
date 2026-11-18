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

            const int Capacity = 100;
            double[] values = new double[Capacity];
            int count = 0;

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
                    case "4": RunDurationCalculation(); Pause(); break;
                    case "5":
                        double newValue = ReadDouble("Введіть число (0–10000): ", 0, 10000);
                        AddValue(values, ref count, newValue, Capacity);
                        Console.WriteLine($"Лічильник у Main після виклику: {count}");
                        Pause();
                        break;
                    case "6":
                        PrintValues(values, count);
                        Pause();
                        break;
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
            Console.WriteLine("5 — Додати значення в масив (лаб. 9)");
            Console.WriteLine("6 — Показати масив (лаб. 9)");
            Console.WriteLine("7 — Видалити за номером (буде пізніше)");
            Console.WriteLine("8 — Статистика (буде пізніше)");
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

        static void ShowTwoDimensionalTable()
        {
            Console.WriteLine("Зведена таблиця в процесі оновлення...");
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
        }

        static double CalculatePlaylistDuration(int trackCount, double avgMinutes)
        {
            return trackCount * avgMinutes;
        }

        static void AddValue(double[] values, ref int count, double newValue, int capacity)
        {
            if (count == capacity)
            {
                Console.WriteLine("Місця більше немає.");
                return;
            }

            values[count] = newValue;
            count++;
        }

        static void PrintValues(double[] values, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("Масив порожній. Спочатку додайте значення (пункт 5).");
                return;
            }

            Console.WriteLine("=== Вміст масиву ===");
            Console.WriteLine("+------+----------------------+");
            Console.WriteLine("| №    | Значення             |");
            Console.WriteLine("+------+----------------------+");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"| {i + 1,-4} | {values[i],20:F2} |");
            }

            Console.WriteLine("+------+----------------------+");
            Console.WriteLine($"Елементів: {count}");
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

        static void RunDurationCalculation()
        {
            Console.WriteLine("=== Розрахунок загальної тривалості плейлиста ===");
            int count = ReadInt("Введіть кількість треків (1–500): ", 1, 500);
            double avgMinutes = ReadDouble("Введіть середню тривалість треку в хв (0.5–30.0): ", 0.5, 30.0);

            double total = CalculatePlaylistDuration(count, avgMinutes);
            Console.WriteLine($"Загальна тривалість плейлиста: {total:F2} хв.");
        }

        static void RunTabulation()
        {
            Console.WriteLine("=== Табулювання: розмір WAV-файлу від часу ===");
            double from = ReadDouble("Введіть початковий час (хв, мін 1.0): ", 1.0, 10.0);
            double to = ReadDouble("Введіть кінцевий час (хв, макс 20.0): ", from, 20.0);
            double step = ReadDouble("Введіть крок (0.1–2.0): ", 0.1, 2.0);
            double mbPerMinute = 10.094;

            Console.WriteLine("+----------------------+----------------------+");
            Console.WriteLine("| Тривалість t (хв)    | Орієнтовний обсяг MB |");
            Console.WriteLine("+----------------------+----------------------+");

            for (double t = from; t <= to + 1e-9; t += step)
            {
                double size = t * mbPerMinute;
                Console.WriteLine($"| {t,20:F2} | {size,20:F2} |");
            }
            Console.WriteLine("+----------------------+----------------------+");
        }
    }
}