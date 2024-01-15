using App.Structs;
using App.Toolkit;


namespace App.UI
{
    public class Menus
    {
        Toolkits toolkits = new Toolkits();
        Fonts fonts = new Fonts();

        public void Menu(UserStruct user)
        {
            Console.Clear();
            Console.WriteLine("       _____ ______   _______   ________   ___  ___     \r\n      |\\   _ \\  _   \\|\\  ___ \\ |\\   ___  \\|\\  \\|\\  \\    \r\n      \\ \\  \\\\\\__\\ \\  \\ \\   __/|\\ \\  \\\\ \\  \\ \\  \\\\\\  \\   \r\n       \\ \\  \\\\|__| \\  \\ \\  \\_|/_\\ \\  \\\\ \\  \\ \\  \\\\\\  \\  \r\n        \\ \\  \\    \\ \\  \\ \\  \\_|\\ \\ \\  \\\\ \\  \\ \\  \\\\\\  \\ \r\n         \\ \\__\\    \\ \\__\\ \\_______\\ \\__\\\\ \\__\\ \\_______\\\r\n          \\|__|     \\|__|\\|_______|\\|__| \\|__|\\|_______|");
            Console.WriteLine($"\n\t\t    C U R R E N T   U S E R: {user.Name}");
            Console.WriteLine($"\t\t    R O L E: {(user.Role ? "Admin" : "Normal user")}");
            List<string> listNormalUser = [
                                    "Check account",
                                    "Find product",
                                    "Buy product",
                                    "About program",          // Created
                                    "Exit"
                                        ];
            List<string> listAdminUser = [
                                    "Check account",
                                    "Find product",
                                    "Buy product",
                                    "About program",
                                    "Products control menu",
                                    "Users control menu",
                                    "Exit"
                                        ];
            toolkits.DisplayMenuList(user.Role ? listAdminUser : listNormalUser);
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("       ________  ________  _____ ______   ________  ________  ___  __    _______  _________   \r\n      |\\   __  \\|\\   ____\\|\\   _ \\  _   \\|\\   __  \\|\\   __  \\|\\  \\|\\  \\ |\\  ___ \\|\\___   ___\\ \r\n      \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\\\\\__\\ \\  \\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\/  /|\\ \\   __/\\|___ \\  \\_| \r\n       \\ \\   ____\\ \\  \\    \\ \\  \\\\|__| \\  \\ \\   __  \\ \\   _  _\\ \\   ___  \\ \\  \\_|/__  \\ \\  \\  \r\n        \\ \\  \\___|\\ \\  \\____\\ \\  \\    \\ \\  \\ \\  \\ \\  \\ \\  \\\\  \\\\ \\  \\\\ \\  \\ \\  \\_|\\ \\  \\ \\  \\ \r\n         \\ \\__\\    \\ \\_______\\ \\__\\    \\ \\__\\ \\__\\ \\__\\ \\__\\\\ _\\\\ \\__\\\\ \\__\\ \\_______\\  \\ \\__\\\r\n          \\|__|     \\|_______|\\|__|     \\|__|\\|__|\\|__|\\|__|\\|__|\\|__| \\|__|\\|_______|   \\|__|");
            Console.WriteLine("\n\t\t    W E L C O M E   I N T O   O U R   P - C   M A R K E T");
            fonts.RedText("Y O U`R E   N O T   L O G I N");
            List<string> list = [
                                    "Login",
                                    "Create account",
                                    "Exit"
                                ];
            toolkits.DisplayMenuList(list);
        }
    }
}