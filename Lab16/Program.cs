using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                products[i] = new Product();
                Console.WriteLine("Введите код продукта");
                products[i].Code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название продукта");
                products[i].Name = Console.ReadLine();
                Console.WriteLine("Введите цену продукта");
                products[i].Price = Convert.ToDouble(Console.ReadLine());
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            Console.WriteLine(jsonString);
            string path = "E:\\C_sharp_projects\\Products.json";
            /*if (!File.Exists(path))
            {
                File.Create(path);
            }*/
            using (StreamWriter sw = new StreamWriter(path, false))
            {

                    sw.WriteLine(jsonString);
            }
            Console.ReadKey();
        }
    }
}
