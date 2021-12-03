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

namespace HomeWork16_1
{
    class Program
    {
        //1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
        //Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара»(целое число), «Название товара»(строка), «Цена товара»(вещественное число).
        //Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
        //Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».        
        static void Main(string[] args)
        {
            string path = "MyFiles";
            string fileName = "/File.json";
            int productCount = 0;
            while (productCount == 0)
            {
                try
                {
                    Console.WriteLine("Введите количество позиций товаров, которые хотите ввести в массив:");
                    productCount = Int32.Parse(Console.ReadLine());                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Product[] productArray = new Product[productCount];
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"Товар №{i + 1}:");
                productArray[i] = new Product();
                Console.Clear();
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(productArray, options);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (Directory.Exists(path) && !File.Exists(path + fileName))
            {
                File.Create(path + fileName).Close();
            }
            if (Directory.Exists(path) && File.Exists(path + fileName))
            {
                using (StreamWriter myFileWrite = new StreamWriter(path + fileName))
                {
                    myFileWrite.Write(jsonString);
                }
            }
            Console.WriteLine(jsonString);
            Console.ReadKey();
        }
    }
    
}
