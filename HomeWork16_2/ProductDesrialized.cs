using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeWork16_2
{    public class ProductDesrialized
    {
        [JsonPropertyName("название")]
        public string Name { get; set; }
        [JsonPropertyName("артикул")]
        public int Article { get; set; }
        [JsonPropertyName("цена с НДС")]
        public decimal Price { get; set; }
        [JsonPropertyName("цена без НДС")]
        public decimal PriceWVat { get; set; }
    }
}
