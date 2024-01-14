
namespace App.Toolkit
{
    public class Fonts
    {
        public void GreenText(string text, bool readKey = false)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t    {text}");
            Console.ResetColor();
            if (readKey)
            {
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void OrangeText(string text, bool readKey = false)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t\t    {text}");
            Console.ResetColor();
            if (readKey)
            {
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void RedText(string text, bool readKey = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t\t    {text}");
            Console.ResetColor();
            if (readKey)
            {
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}