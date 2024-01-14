using App.Toolkit;
using App.Structs;



namespace App.UI
{
    internal class Interfaces
    {
        private bool validationData = false;
        private bool findUser = false;
        private string name;
        private string surname;
        private string email;
        private string password;
        private bool isAdmin;
        private UserStruct userData;
        Toolkits toolkits = new Toolkits();
        Tokens tokens = new Tokens();
        Fonts fonts = new Fonts();

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

        public UserStruct Login()
        {
            while(!this.validationData || !this.findUser)
            {
                Console.Clear();
                Console.WriteLine("       ___       ________  ________  ___  ________      \r\n      |\\  \\     |\\   __  \\|\\   ____\\|\\  \\|\\   ___  \\    \r\n      \\ \\  \\    \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\ \\  \\\\ \\  \\   \r\n       \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\  __\\ \\  \\ \\  \\\\ \\  \\  \r\n        \\ \\  \\____\\ \\  \\\\\\  \\ \\  \\|\\  \\ \\  \\ \\  \\\\ \\  \\ \r\n         \\ \\_______\\ \\_______\\ \\_______\\ \\__\\ \\__\\\\ \\__\\\r\n          \\|_______|\\|_______|\\|_______|\\|__|\\|__| \\|__|");

                Console.Write("\n\t\t    Username:");
                this.name = Console.ReadLine();
                Console.Write("\n\t\t    Surname:");
                this.surname = Console.ReadLine();
                Console.Write("\n\t\t    Email:");
                this.email = Console.ReadLine();
                Console.Write("\n\t\t    Password:");
                this.password = Console.ReadLine();

                this.validationData = toolkits.UserDataValidator(this.name, this.surname, this.email, this.password);

                if (this.validationData)
                {
                    this.findUser = toolkits.LoginHandler(this.name, this.surname, this.email, this.password);

                    if (this.findUser)
                    {
                        fonts.GreenText($"Welcome, {this.name}");
                        fonts.GreenText("Press any key to continue...", true);
                        
                        this.isAdmin = toolkits.CheckUserRole(this.name, this.surname, this.email, this.password);

                        this.userData = new UserStruct(this.name, this.surname, this.email, this.password, this.isAdmin);
                        break;
                    }
                    else
                    {
                        fonts.RedText("Incorrect data. Try again.");
                        fonts.OrangeText("Press any key to try again...", true);
                    }
                }
                else
                {
                    fonts.RedText("Invalid data. Try again.");
                    fonts.OrangeText("Press any key to try again...", true);
                }
            }
            return userData;
        }

        public void CreateAccount()
        {
            string confPassword;

            while(!this.validationData)
            {
                Console.Clear();
                Console.WriteLine("        ________  ________  _______   ________  _________  ___  ________   ________     \r\n       |\\   ____\\|\\   __  \\|\\  ___ \\ |\\   __  \\|\\___   ___\\\\  \\|\\   ___  \\|\\   ____\\    \r\n       \\ \\  \\___|\\ \\  \\|\\  \\ \\   __/|\\ \\  \\|\\  \\|___ \\  \\_\\ \\  \\ \\  \\\\ \\  \\ \\  \\___|    \r\n        \\ \\  \\    \\ \\   _  _\\ \\  \\_|/_\\ \\   __  \\   \\ \\  \\ \\ \\  \\ \\  \\\\ \\  \\ \\  \\  ___  \r\n         \\ \\  \\____\\ \\  \\\\  \\\\ \\  \\_|\\ \\ \\  \\ \\  \\   \\ \\  \\ \\ \\  \\ \\  \\\\ \\  \\ \\  \\|\\  \\ \r\n          \\ \\_______\\ \\__\\\\ _\\\\ \\_______\\ \\__\\ \\__\\   \\ \\__\\ \\ \\__\\ \\__\\\\ \\__\\ \\_______\\\r\n           \\|_______|\\|__|\\|__|\\|_______|\\|__|\\|__|    \\|__|  \\|__|\\|__| \\|__|\\|_______|\r\n        ________  ________  ________  ________  ___  ___  ________   _________          \r\n       |\\   __  \\|\\   ____\\|\\   ____\\|\\   __  \\|\\  \\|\\  \\|\\   ___  \\|\\___   ___\\        \r\n       \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\|___ \\  \\_|        \r\n        \\ \\   __  \\ \\  \\    \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\         \r\n         \\ \\  \\ \\  \\ \\  \\____\\ \\  \\____\\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\        \r\n          \\ \\__\\ \\__\\ \\_______\\ \\_______\\ \\_______\\ \\_______\\ \\__\\\\ \\__\\   \\ \\__\\       \r\n           \\|__|\\|__|\\|_______|\\|_______|\\|_______|\\|_______|\\|__| \\|__|    \\|__|       ");
                fonts.OrangeText("The name must not include special characters.\r\n\t\t    The minimum password length is 6 characters.");
                Console.Write("\n\t\t    Username:");
                this.name = Console.ReadLine() ?? "";
                Console.Write("\t\t    Surname:");
                this.surname = Console.ReadLine() ?? "";
                Console.Write("\t\t    Email:");
                this.email = Console.ReadLine() ?? "";
                Console.Write("\t\t    Password:");
                this.password = Console.ReadLine() ?? "";
                Console.Write("\t\t    Confirm password:");
                confPassword = Console.ReadLine() ?? "";


                if (this.toolkits.UserDataValidator(this.name, this.surname, this.email, this.password) && this.password.Equals(confPassword))
                {
                    UserStruct newUser = new UserStruct(this.name, this.surname, this.email, this.password, false);
                    if(toolkits.CreateAccount(newUser))
                    {
                        fonts.GreenText("A C C O U N T   C R E A T E D");
                        fonts.GreenText("Press any key to continue...", true);
                        break;
                    }
                    else
                    {
                        fonts.RedText("C R E A T I N G   A C C O U N T   E R R O R. T R Y   A G A I N ");
                        fonts.OrangeText("Press any key to try again...", true);
                    }
                }
                else
                {
                    fonts.RedText("I N C O R R E C T   D A T A. T R Y   A G A I N");
                    fonts.OrangeText("Press any key to try again...", true);
                }
            }
        }

        public void Menu()
        {
            Console.WriteLine("       _____ ______   _______   ________   ___  ___     \r\n      |\\   _ \\  _   \\|\\  ___ \\ |\\   ___  \\|\\  \\|\\  \\    \r\n      \\ \\  \\\\\\__\\ \\  \\ \\   __/|\\ \\  \\\\ \\  \\ \\  \\\\\\  \\   \r\n       \\ \\  \\\\|__| \\  \\ \\  \\_|/_\\ \\  \\\\ \\  \\ \\  \\\\\\  \\  \r\n        \\ \\  \\    \\ \\  \\ \\  \\_|\\ \\ \\  \\\\ \\  \\ \\  \\\\\\  \\ \r\n         \\ \\__\\    \\ \\__\\ \\_______\\ \\__\\\\ \\__\\ \\_______\\\r\n          \\|__|     \\|__|\\|_______|\\|__| \\|__|\\|_______|");
            Console.WriteLine($"\n\t\t    C U R R E N T   U S E R: {this.name}");
            Console.WriteLine($"\t\t    R O L E: {(this.isAdmin ? "Admin" : "Normal user")}");
            List<string> listNormalUser = [
                                    "Check account",
                                    "Find product",
                                    "Buy product",
                                    "About program",
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
            toolkits.DisplayMenuList(this.isAdmin ? listAdminUser : listNormalUser);
        }

        public void Exit()
        {
            Console.Clear ();
            Console.WriteLine("        ________      ___    ___ _______      \r\n       |\\   __  \\    |\\  \\  /  /|\\  ___ \\     \r\n       \\ \\  \\|\\ /_   \\ \\  \\/  / | \\   __/|    \r\n        \\ \\   __  \\   \\ \\    / / \\ \\  \\_|/__  \r\n         \\ \\  \\|\\  \\   \\/  /  /   \\ \\  \\_|\\ \\ \r\n          \\ \\_______\\__/  / /      \\ \\_______\\\r\n           \\|_______|\\___/ /        \\|_______|\r\n                    \\|___|/                   ");
            Console.WriteLine($"\n\t\t    B Y E    {this.name}");
            fonts.OrangeText("Press any key to continue...", true);
        }
    }
}
