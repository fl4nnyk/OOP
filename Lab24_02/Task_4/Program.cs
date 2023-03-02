using System;
using System.Collections.Generic;

namespace Task_4
{
    class Program
    {
        delegate int StringLength(string str);

        static void Main(string[] args)
        {
            List<string> strings = new List<string>() { "Hello", "world" };

            // Створюємо делегат
            StringLength lengthDelegate = str => str.Length;

            foreach (string str in strings)
            {
                int length = lengthDelegate(str);
                Console.WriteLine($"Довжина рядка '{str}' дорівнює {length}");
            }
        }
    }
}