/*
using System;
using System.IO;

namespace TextCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Текстовый калькулятор:\nСтрока 1:");
            string strochka1 = Console.ReadLine();
            DateTime time1 = DateTime.Now;
            Console.WriteLine("Строка 2:");
            string strochka2 = Console.ReadLine();
            DateTime time2 = DateTime.Now;
            string result = strochka1 + strochka2;
            Console.WriteLine($"Результат: {result}");
            DateTime timeRes = DateTime.Now;
            FileStream T = new FileStream($"log_{DateTime.Now:yyyy-MM-dd}.txt", FileMode.Append, FileAccess.Write);
            string[] inf = 
                {
                $"Time:{time1} - Entering a line: {strochka1}",
                $"Time:{time2} - Entering 2 lines: {strochka2}",
                $"Time:{timeRes} - Result: {result}",
                };
            foreach (string line in inf)
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(line + Environment.NewLine);
                T.Write(bytes, 0, bytes.Length);
            }
            T.Close();
        }
    }
}
*/