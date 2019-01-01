using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CheckTransformations
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine("first execution");
            stopwatch.Start();
            var a1 = Test();
            stopwatch.Stop();
            WriteToFile(1, a1);
            Console.WriteLine($"time: {stopwatch.Elapsed}");
            stopwatch.Reset();
            Console.WriteLine("second execution");
            stopwatch.Start();
            var a2 = Test();
            stopwatch.Stop();
            WriteToFile(2, a2);
            Console.WriteLine($"time: {stopwatch.Elapsed}");
            Console.ReadLine();
        }

        private static void WriteToFile(int i, string a1)
        {
            using (var x = new StreamWriter(
                new FileStream($"C:\\Users\\Krzysztof.Kroczak\\source\\repos\\CheckTransformations\\CheckTransformations\\c{i}.txt",FileMode.Append)))
            {
                x.Write(a1);
            }
        }

        private static string Test()
        {
            return string.Concat(Enumerable.Range(0, 500_001)
                .Where(x => x % 5 == 0)
                .Select(x => x * 2)
                .Select(x => x.ToString()));
        }
    }
}
