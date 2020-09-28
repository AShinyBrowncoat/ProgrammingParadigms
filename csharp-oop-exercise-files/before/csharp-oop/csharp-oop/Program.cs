using System;
using System.Collections.Generic;
using System.IO;

namespace csharp_oop
{
    class Program
    {
        static void Main(string[] args)
        {

            var date = new List<DateTime>();
            var open = new List<decimal>();
            var high = new List<decimal>();
            var low = new List<decimal>();
            var close = new List<decimal>();

            var lines = File.ReadAllLines(args[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split(',');
                date.Add(DateTime.Parse(data[0]));
                open.Add(decimal.Parse(data[1]));
                high.Add(decimal.Parse(data[2]));
                low.Add(decimal.Parse(data[3]));
                close.Add(decimal.Parse(data[4]));
            }

            for (int i = 0; i < date.Count - 4; i++)
            {
                if (open[i] > high[i + 1] && close[i] < low[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pivot downside {0}", date[i].ToShortDateString());
                }
                if (open[i] < low[i + 1] && close[i] > high[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pivot upside {0}", date[i].ToShortDateString());
                }
            }
        }
    }
}
