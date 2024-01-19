using Newtonsoft.Json;
using App.Structs;



namespace App.Toolkit
{
    internal class Toolkits
    {
        private Fonts fonts = new Fonts();

        public byte CheckUserInput()
        {
            byte result = 0;
            while (result == 0)
            {
                try
                {
                    Console.Write("\n\t\t    >>>");
                    result = Convert.ToByte(Console.ReadLine());
                }
                catch
                {
                    fonts.RedText("T R Y   A G A I N");
                }
            }
            return result;
        }

        public int CheckUserInputInt()
        {
            int result = 0;
            while (result == 0)
            {
                try
                {
                    Console.Write("\n\t\t    >>>");
                    result = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    fonts.RedText("T R Y   A G A I N");
                }
            }
            return result;
        }

        public List<UserStruct> GetDataFromUsersJsonFile(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UserStruct>>(jsonContent) ?? new List<UserStruct>();
        }

        public List<ProductStruct> GetDataFromProductsJsonFile(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ProductStruct>>(jsonContent) ?? new List<ProductStruct>();
        }

        public void DisplayMenuList(List<string> list)
        {
            Console.WriteLine($"\n\t\t    Choose options(1 - {list.Count}):");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\t\t      {i+1}. {list[i]}");
            }
        }
    }
}
