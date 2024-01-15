using App.Toolkit;
using App.Structs;



namespace App.UI
{
    internal class Interfaces
    {
        private bool validationData = false;
        private bool findUser = false;
        private UserStruct userData;
        private UserStruct tempUserData;
        Toolkits toolkits = new Toolkits();
        Tokens tokens = new Tokens();
        Fonts fonts = new Fonts();
        Menus menuInterfaces = new Menus();


        public UserStruct Login()
        {
            while(!this.validationData || !this.findUser)
            {
                Console.Clear();
                Console.WriteLine("       ___       ________  ________  ___  ________      \r\n      |\\  \\     |\\   __  \\|\\   ____\\|\\  \\|\\   ___  \\    \r\n      \\ \\  \\    \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\ \\  \\\\ \\  \\   \r\n       \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\  __\\ \\  \\ \\  \\\\ \\  \\  \r\n        \\ \\  \\____\\ \\  \\\\\\  \\ \\  \\|\\  \\ \\  \\ \\  \\\\ \\  \\ \r\n         \\ \\_______\\ \\_______\\ \\_______\\ \\__\\ \\__\\\\ \\__\\\r\n          \\|_______|\\|_______|\\|_______|\\|__|\\|__| \\|__|");

                Console.Write("\n\t\t    Username:");
                this.tempUserData.Name = Console.ReadLine() ?? "";
                Console.Write("\n\t\t    Surname:");
                this.tempUserData.Surname = Console.ReadLine() ?? "";
                Console.Write("\n\t\t    Email:");
                this.tempUserData.Email = Console.ReadLine() ?? "";
                Console.Write("\n\t\t    Password:");
                this.tempUserData.Password = Console.ReadLine() ?? "";

                this.validationData = toolkits.UserDataValidator(this.tempUserData);

                if (this.validationData)
                {
                    this.findUser = toolkits.LoginHandler(this.tempUserData);

                    if (this.findUser)
                    {
                        fonts.GreenText($"Welcome, {this.tempUserData.Name}");
                        fonts.GreenText("Press any key to continue...", true);
                        
                        this.tempUserData.Role = toolkits.CheckUserRole(this.tempUserData);

                        this.userData = this.tempUserData;
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
                this.tempUserData.Name = Console.ReadLine() ?? "";
                Console.Write("\t\t    Surname:");
                this.tempUserData.Surname = Console.ReadLine() ?? "";
                Console.Write("\t\t    Email:");
                this.tempUserData.Email = Console.ReadLine() ?? "";
                Console.Write("\t\t    Password:");
                this.tempUserData.Password = Console.ReadLine() ?? "";
                Console.Write("\t\t    Confirm password:");
                confPassword = Console.ReadLine() ?? "";


                if (this.toolkits.UserDataValidator(this.tempUserData) && this.tempUserData.Password.Equals(confPassword))
                {
                    UserStruct newUser = this.tempUserData;
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

        public void EditUserAccount(UserStruct user)
        {
            Console.Clear();
            Console.WriteLine("\n\t\t    Editttttttt");
            toolkits.CheckUserInput();
        }

        public void CheckAccount()
        {
            Console.Clear();
            Console.WriteLine("        ___  ___  ________  _______   ________                                   \r\n       |\\  \\|\\  \\|\\   ____\\|\\  ___ \\ |\\   __  \\                                  \r\n       \\ \\  \\\\\\  \\ \\  \\___|\\ \\   __/|\\ \\  \\|\\  \\                                 \r\n        \\ \\  \\\\\\  \\ \\_____  \\ \\  \\_|/_\\ \\   _  _\\                                \r\n         \\ \\  \\\\\\  \\|____|\\  \\ \\  \\_|\\ \\ \\  \\\\  \\|                               \r\n          \\ \\_______\\____\\_\\  \\ \\_______\\ \\__\\\\ _\\                               \r\n           \\|_______|\\_________\\|_______|\\|__|\\|__|                              \r\n        ________  __________________  ________  ___  ___  ________   _________   \r\n       |\\   __  \\|\\   ____\\|\\   ____\\|\\   __  \\|\\  \\|\\  \\|\\   ___  \\|\\___   ___\\ \r\n       \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\|___ \\  \\_| \r\n        \\ \\   __  \\ \\  \\    \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\  \r\n         \\ \\  \\ \\  \\ \\  \\____\\ \\  \\____\\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\ \r\n          \\ \\__\\ \\__\\ \\_______\\ \\_______\\ \\_______\\ \\_______\\ \\__\\\\ \\__\\   \\ \\__\\\r\n           \\|__|\\|__|\\|_______|\\|_______|\\|_______|\\|_______|\\|__| \\|__|    \\|__|");
            Console.WriteLine($"\n\t\t    User name: {this.userData.Name}");
            Console.WriteLine($"\t\t    Surname: {this.userData.Surname}");
            Console.WriteLine($"\t\t    Email: {this.userData.Email}");
            Console.WriteLine($"\t\t    Password: {this.userData.Password}");
            Console.WriteLine($"\t\t    {(this.userData.Role ? "Admin" : "Normal user")}");

            List<string> accountMenu = [
                                        "Edit account",
                                        "Exit"
                                    ];
            toolkits.DisplayMenuList(accountMenu);
            byte input = toolkits.CheckUserInput();
            switch (input)
            {
                case 1:
                    EditUserAccount(this.userData);
                    break;
                case 2:
                    menuInterfaces.Menu(this.userData);
                    break;
            }
        }

        public void About()
        {
            Console.Clear();
            Console.WriteLine("        ________  ________  ________  ___  ___  _________   \r\n       |\\   __  \\|\\   __  \\|\\   __  \\|\\  \\|\\  \\|\\___   ___\\ \r\n       \\ \\  \\|\\  \\ \\  \\|\\ /\\ \\  \\|\\  \\ \\  \\\\\\  \\|___ \\  \\_| \r\n        \\ \\   __  \\ \\   __  \\ \\  \\\\\\  \\ \\  \\\\\\  \\   \\ \\  \\  \r\n         \\ \\  \\ \\  \\ \\  \\|\\  \\ \\  \\\\\\  \\ \\  \\\\\\  \\   \\ \\  \\ \r\n          \\ \\__\\ \\__\\ \\_______\\ \\_______\\ \\_______\\   \\ \\__\\\r\n           \\|__|\\|__|\\|_______|\\|_______|\\|_______|    \\|__|");
            Console.WriteLine("\n\t\t    PCMARKET is a personal pet project, a minimarket where PC components are sold.");
            Console.WriteLine("\n\t\t    The program provides the ability to manage products, divide them into \n\t\t    regular users and administrators, and also manage their rights depending on their role.");
            Console.WriteLine("\t\t    The program allows administrators to control sales and users. Users can view their account and make purchases.");
            fonts.OrangeText("Press any key to leave...", true);
        }

        public void Exit()
        {
            Console.Clear ();
            Console.WriteLine("        ________      ___    ___ _______      \r\n       |\\   __  \\    |\\  \\  /  /|\\  ___ \\     \r\n       \\ \\  \\|\\ /_   \\ \\  \\/  / | \\   __/|    \r\n        \\ \\   __  \\   \\ \\    / / \\ \\  \\_|/__  \r\n         \\ \\  \\|\\  \\   \\/  /  /   \\ \\  \\_|\\ \\ \r\n          \\ \\_______\\__/  / /      \\ \\_______\\\r\n           \\|_______|\\___/ /        \\|_______|\r\n                    \\|___|/                   ");
            Console.WriteLine($"\n\t\t    B Y E    {this.userData.Name}");
            fonts.OrangeText("Press any key to continue...", true);
        }
    }
}
