using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "transactions.csv";
        string dateFormat = "dd/MM/yyyy";

        Func<string, DateTime> getDate = str => DateTime.ParseExact(str, dateFormat, CultureInfo.InvariantCulture);
        Func<string, double> getAmount = str => double.Parse(str, CultureInfo.InvariantCulture);

        Action<DateTime, double> displayTotal = (date, total) =>
        {
            Console.WriteLine($"On {date.ToString(dateFormat)}, total amount spent: {total.ToString("C")}");
        };

        int batchSize = 10;
        List<string> lines = File.ReadAllLines(filePath).ToList();

        for (int i = 0; i < lines.Count; i += batchSize)
        {
            List<string> batch = lines.Skip(i).Take(batchSize).ToList();
            List<Transaction> transactions = batch.Select(line => new Transaction(line, getDate, getAmount)).ToList();
            var groupByDate = transactions.GroupBy(t => t.Date);
            foreach (var group in groupByDate)
            {
                double total = group.Sum(t => t.Amount);
                displayTotal(group.Key, total);
            }
        }
    }

    class Transaction
    {
        public DateTime Date { get; }
        public double Amount { get; }

        public Transaction(string line, Func<string, DateTime> getDate, Func<string, double> getAmount)
        {
            string[] parts = line.Split(',');
            Date = getDate(parts[0]);
            Amount = getAmount(parts[1]);
        }
    }
}
