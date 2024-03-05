using System;
using System.IO;

namespace _MDK_0104_Practice_9_
{
    class Program
    {
        static DateTime currentTime = DateTime.Now;
        static UInt64 K = 0;

        static void Main()
        {
            Console.WriteLine("Tekstovyi kalkulyator:\nStroka 1:");
            string stroka1 = Console.ReadLine();
            Console.WriteLine("Stroka 2:");
            string stroka2 = Console.ReadLine();

            string rezultat = stroka1 + stroka2;
            Console.WriteLine($"Rezultat: {rezultat}");
            K++;

            string logFilePath = SozdatLogFayl(currentTime);
            LogirovatOperatsiyu(logFilePath, stroka1, stroka2, rezultat, currentTime);

            string resultFilePath = SohranitRezultat(rezultat);
            Console.WriteLine($"Rezultat sohranen v fayle: {resultFilePath}");

            Console.Write("\nНажмите Enter для продолжения работы программы или Esc для завершения");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                Main();
            }
            else if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }

        public static string SozdatLogFayl(DateTime currentTime)
        {
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", $"log_{currentTime:yyyyMMdd_HHmmss}.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
            return logFilePath;
        }

        public static void LogirovatOperatsiyu(string logFilePath, string stroka1, string stroka2, string rezultat, DateTime currentTime)
        {
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine($"{currentTime} - Nachalo Rabot: ");
                writer.WriteLine($"{currentTime} - Vvedena pervaya stroka: {stroka1}");
                writer.WriteLine($"{currentTime} - Vvedena vtoraia stroka: {stroka2}");
                writer.WriteLine($"{currentTime} - Rezultat stseplenia: {rezultat}");
                writer.WriteLine($"{currentTime} - Kolichestvo raz vypolneniya stseplenia: {K}");
                writer.WriteLine($"{currentTime} - Konetc Rabot");
            }
        }

        public static string SohranitRezultat(string rezultat)
        {
            string resultFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Results", $"result_{DateTime.Now:yyyyMMdd}.txt");
            File.AppendAllText(resultFilePath, $"\n{DateTime.Now:HH:mm:ss}: {rezultat}");
            return resultFilePath;
        }
    }
}
