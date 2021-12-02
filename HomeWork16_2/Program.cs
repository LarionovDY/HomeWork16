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
            HomeWork16_1.Product[] person = JsonSerializer.Deserialize<HomeWork16_1.Product[]>(jsonString);
            foreach (var item in person)
            {
                Console.WriteLine(person);
            }
            Console.ReadKey();
        }
    }
}
