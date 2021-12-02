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
    public class Product
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
        protected internal Product()
        {
            Console.WriteLine("Введите название товара:");
            Name = Console.ReadLine();
            Article = ReadIntValue("Введите артикул товара:");
            Price = ReadDecValue("Введите цену с НДС");
            this.vat = ReadDecValue("Введите ставку НДС в процентах");
            PriceWVat = Math.Round(Price / (1 + this.vat / 100), 2);
        }
        protected int ReadIntValue(string text)   //метод проверяющий корректность ввода данных
        {
            int value;
            while (true)
            {
                Console.WriteLine(text);
                if (Int32.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен");
                }
            }
        }
        protected decimal ReadDecValue(string text)   //метод проверяющий корректность ввода данных
        {
            decimal value;
            while (true)
            {
                Console.WriteLine(text);
                if (Decimal.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен");
                }
            }
        }
    }
}
