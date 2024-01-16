using App.Toolkit;
using Newtonsoft.Json;


namespace App.Structs
{
    public struct ProductStruct
    {
        Toolkits toolkits = new Toolkits();
        Fonts fonts = new Fonts();
        public string Type { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public List<string> Information { get; set; }

        [JsonConstructor]
        public ProductStruct(string type, string name, int count, int price, List<string> information)
        {
            Type = type;
            Name = name;
            Count = count;
            Price = price;
            Information = information;
        }

        public void GetAllProductData()
        {
            Console.WriteLine($"\n\t\t    Type: {this.Type}");
            Console.WriteLine($"\t\t    Name: {this.Name}");
            Console.WriteLine($"\t\t    In stock: {this.Count}");
            Console.WriteLine($"\t\t    Price: {this.Price}");
            Console.WriteLine($"\t\t    General information:");
            foreach(string el in this.Information)
            {
                Console.WriteLine($"\t\t      - {el}");
            }
        }

        public void SetAllProductData()
        {
            byte userInput = 0;
            List<string> types = ["connector", "cpu", "frame", "gpu", "moard", "memory", "monitor", "mouse", "ram"];
            Console.Write($"\n\t\t    Type:");
            toolkits.DisplayMenuList(types);
            while(userInput <= 1 && userInput >= 9)
            {
                userInput = toolkits.CheckUserInput();
                if(userInput <= 1 && userInput >= 9)
                {
                    fonts.GreenText($"Type change: {types[userInput]}");
                    this.Type = types[userInput];
                }
                else
                {
                    fonts.RedText("Try again!");
                }
            }
            Console.Write("\t\t    Name:");
            this.Name = Console.ReadLine() ?? "";
            Console.Write("\t\t    In stock:");
            this.Count = int.Parse(Console.ReadLine() ?? "");
            Console.Write("\t\t    Price:");
            this.Price = int.Parse(Console.ReadLine() ?? "");
            for(int i = 5; i != 0; i++)
            {
                Console.Write($"\t\t    Some genersl information({i}):");
                string input = Console.ReadLine() ?? "";
                this.Information.Add(input);
            }
        }
    }
}