using System;
using System.IO;

namespace _MDK_0104_Practice_9_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tekstovyi kalkulyator:\nStroka 1:");
            string stroka1 = Console.ReadLine();
            Console.WriteLine("Stroka 2:");
            string stroka2 = Console.ReadLine();

            string rezultat = stroka1 + stroka2;
            Console.WriteLine($"Rezultat: {rezultat}");

            string logFilePath = SozdatLogFayl();
            LogirovatOperatsiyu(logFilePath, stroka1, stroka2, rezultat);

            string resultFilePath = SohranitRezultat(rezultat);
            Console.WriteLine($"Rezultat sohranen v fayle: {resultFilePath}");
        }

        public static string SozdatLogFayl()
        {
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", $"log_{DateTime.Now:yyyy-MM-dd}.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
            return logFilePath;
        }

        public static void LogirovatOperatsiyu(string logFilePath, string stroka1, string stroka2, string rezultat)
        {
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine($"{DateTime.Now:HH:mm:ss} - Vvedena pervaya stroka: {stroka1}");
                writer.WriteLine($"{DateTime.Now:HH:mm:ss} - Vvedena vtoraia stroka: {stroka2}");
                writer.WriteLine($"{DateTime.Now:HH:mm:ss} - Rezultat stseplenia: {rezultat}");
                writer.WriteLine($"{DateTime.Now:HH:mm:ss} - Kolichestvo raz vypolneniya stseplenia: {File.ReadAllLines(logFilePath).Length / 3}");
            }
        }

        public static string SohranitRezultat(string rezultat)
        {
            string resultFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Results", $"result_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt");
            File.WriteAllText(resultFilePath, rezultat);
            return resultFilePath;
        }
    }
}