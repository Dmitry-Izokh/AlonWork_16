using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace AlonWork_16
{
    class Program
    {
        static void Main(string[] args)
        {            
            const int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {

            
                Console.WriteLine("Введите номер товара");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите стоимость товара");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                products[i] = new Product() {Num=num, Name=name, Price=price };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            using (StreamWriter sw = new StreamWriter("../../../../products.json"))
            {
                sw.WriteLine(jsonString);
            }

        }
    }
}
