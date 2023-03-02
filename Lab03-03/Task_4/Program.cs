using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var files = Directory.GetFiles(@"C:\TextFiles\", "*.txt");

        var tokenize = new Func<string, IEnumerable<string>>(s => s.Split(' '));
        var countWords = new Func<IEnumerable<string>, IDictionary<string, int>>(words =>
        {
            var counts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts[word] = 1;
                }
            }
            return counts;
        });
        var printReport = new Action<IDictionary<string, int>>(counts =>
        {
            foreach (var pair in counts.OrderByDescending(p => p.Value))
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        });

        foreach (var file in files)
        {
            var text = File.ReadAllText(file);
            var words = tokenize(text);
            var counts = countWords(words);
            Console.WriteLine("File: {0}", file);
            printReport(counts);
            Console.WriteLine();
        }
    }
}
