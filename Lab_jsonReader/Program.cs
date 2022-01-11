using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Lab_jsonReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\C_sharp_projects\\Products.json";
            string jsonString = String.Empty;
            string mostExpensiveProduct = String.Empty;
            double maxPrice = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            foreach (Product product in products)
            {
                if (product.Price > maxPrice)
                {
                    maxPrice = product.Price;
                    mostExpensiveProduct = product.Name;
                }
            }
            Console.WriteLine("Самый дорогой продукт {0}", mostExpensiveProduct);
            Console.ReadKey();
        }
    }
}
