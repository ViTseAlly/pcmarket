using System;
using System.Collections.Generic;
using System.Linq;
using App.Path;
using App.Toolkit;
using Newtonsoft.Json;

namespace App.Structs
{
    public struct ProductStruct
    {
        Toolkits toolkits = new Toolkits();
        PathToFiles pathToFiles = new PathToFiles();

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Information { get; set; }

        [JsonConstructor]
        public ProductStruct(int id, string type, string name, int count, int price, string information)
        {
            Id = id;
            Type = type;
            Name = name;
            Count = count;
            Price = price;
            Information = information;
        }


        public void GetAllProductData()
        {
            Console.WriteLine($"\n\t\t    Id: {Id}");
            Console.WriteLine($"\t\t    Type: {Type}");
            Console.WriteLine($"\t\t    Name: {Name}");
            Console.WriteLine($"\t\t    In stock: {Count}");
            Console.WriteLine($"\t\t    Price: {Price}$");
            Console.WriteLine($"\t\t    Some information: {Information}");
        }

        public void SetAllProductData(List<ProductStruct> productsList)
        {
            Id = productsList[productsList.Count - 1].Id + 1;

            Console.Write("\n\t\t    Type:");
            Type = Console.ReadLine() ?? "";

            Console.Write("\t\t    Name:");
            Name = Console.ReadLine() ?? "";

            Console.Write("\t\t    In stock:");
            string countInput = Console.ReadLine() ?? "";
            Count = int.TryParse(countInput, out int countResult) ? countResult : 0;

            Console.Write("\t\t    Price:");
            string priceInput = Console.ReadLine() ?? "";
            Price = int.TryParse(priceInput, out int priceResult) ? priceResult : 0;

            Console.Write("\t\t    Information:");
            Information = Console.ReadLine() ?? "";
        }
    }
}
