using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork16_2
{
    class Program
    {
        //2.Необходимо разработать программу для получения информации о товаре из json-файла.
        //Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
        static void Main(string[] args)
        {
            string path = "MyFiles";
            string fileName = "/File.json";
            string jsonString;
            using (StreamReader myFileRead = new StreamReader(path + fileName))
            {
                jsonString = myFileRead.ReadToEnd();
            }
            ProductDesrialized[] productArray = JsonSerializer.Deserialize<ProductDesrialized[]>(jsonString);
            ProductDesrialized max = productArray[0];
            for (int i = 0; i < productArray.Length; i++)
            {
                if (max.Price < productArray[i].Price)
                {
                    max = productArray[i];
                }
            }
            Console.WriteLine($"Cамый дорогой товар(ы) в списке:\n{max.Name}");
            foreach (var item in productArray)
            {
                if (max.Price == item.Price && max.Name != item.Name)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.WriteLine($"С ценой {max.Price} рублей");
            Console.ReadKey();
        }
    }
    
}
