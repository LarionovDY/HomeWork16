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
            ProductDesrialize[] productArray = JsonSerializer.Deserialize<ProductDesrialize[]>(jsonString);
            foreach (var item in productArray)
            {
                Console.WriteLine(item.PriceWVat);
            }
            Console.ReadKey();
        }

    }
    public class ProductDesrialize
    {
        [JsonPropertyName("название")]
        public string Name { get; set; }
        [JsonPropertyName("артикул")]
        public int Article { get; set; }
        [JsonPropertyName("цена с НДС")]
        public decimal Price { get; set; }
        [JsonIgnore]
        readonly decimal vat;
        [JsonPropertyName("цена без НДС")]
        public decimal PriceWVat { get; set; }        
    }

}
