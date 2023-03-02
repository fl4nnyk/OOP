using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace LambdaExpressionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT ProductName, CategoryName FROM Products INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID", connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    string productName = reader.GetString(0);
                    string categoryName = reader.GetString(1);
                    Product product = new Product(productName, categoryName);
                    products.Add(product);
                }

                var groupedProducts = products.GroupBy(p => p.Category);

                foreach (var group in groupedProducts)
                {
                    Console.WriteLine("Category: " + group.Key);
                    foreach (var product in group)
                    {
                        Console.WriteLine("\t" + product.Name);
                    }
                }
            }

            Console.ReadLine();
        }
    }

    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Product(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}
