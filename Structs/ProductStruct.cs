using App.Toolkit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace App.Structs
{
    public struct ProductStruct
    {
        private string PATH_TO_PRODUCTS_FILE = "./Data/Components/products.json";
        Toolkits toolkits;
        ProductToolkits prtoolkits = new ProductToolkits();
        Fonts fonts;

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Information { get; set; }

        [JsonConstructor]
        public ProductStruct(int id, string type, string name, int count, int price, string information)
        {
            toolkits = new Toolkits();
            fonts = new Fonts();
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

        public void SetAllProductData()
        {
            List<string> types = new List<string> { "Connector", "CPU", "Frame", "GPU", "Motherboard", "Memory", "Frame", "mouse", "RAM" };
            List<ProductStruct> productsList = toolkits.GetDataFromProductsJsonFile(this.PATH_TO_PRODUCTS_FILE);
            Id = productsList[productsList.Count].Id + 1;

            Console.Write($"\n\t\t    Type:");
            toolkits.DisplayMenuList(types);

            byte userInput = 0;
            while (userInput < 1 || userInput > 9)
            {
                userInput = toolkits.CheckUserInput();
                if (userInput >= 1 && userInput <= 9)
                {
                    fonts.GreenText($"Type change: {types[userInput - 1]}");
                    Type = types[userInput - 1];
                }
                else
                {
                    fonts.RedText("Try again!");
                }
            }

            Console.Write("\t\t    Name:");
            Name = Console.ReadLine() ?? "";

            Console.Write("\t\t    In stock:");
            Count = int.Parse(Console.ReadLine() ?? "");

            Console.Write("\t\t    Price:");
            Price = int.Parse(Console.ReadLine() ?? "");

            Console.Write("\t\t    Information:");
            Information = Console.ReadLine() ?? "";
        }
    }
}
