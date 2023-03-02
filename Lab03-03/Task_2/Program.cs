using System;
using System.IO;
using System.Linq;

class Program
{
    public static object JsonConvert { get; private set; }

    static void Main(string[] args)
    {
        string path = @"C:\path\to\json\files\";
        string[] criteria = { "apple", "banana", "orange" };

        Predicate<Product> filter = p => criteria.Contains(p.Name.ToLower());

        Action<Product> display = p => Console.WriteLine($"{p.Name} ({p.Price:C})");

        for (int i = 1; i <= 10; i++)
        {
            string jsonPath = Path.Combine(path, $"{i}.json");
            string json = File.ReadAllText(jsonPath);
            Product[] products = (Product[])JsonConvert;

            var filteredProducts = products.Where(p => filter(p));

            foreach (var product in filteredProducts)
            {
                display(product);
            }
        }
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}