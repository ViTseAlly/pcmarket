using System.Net;
using App.Toolkit;
using App.Structs;



namespace App.UI
{
    internal class Interfaces
    {
        private bool validationData = false;
        private bool findUser = false;
        private UserStruct userData;

        Toolkits toolkits = new Toolkits();
        UserAccountToolkits uatoolkits = new UserAccountToolkits();
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
            UserStruct tempUserData = new UserStruct();
            
            while(!this.validationData || !this.findUser)
            {
                Console.Clear();
                Console.WriteLine("       ___       ________  ________  ___  ________      \r\n      |\\  \\     |\\   __  \\|\\   ____\\|\\  \\|\\   ___  \\    \r\n      \\ \\  \\    \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\ \\  \\\\ \\  \\   \r\n       \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\  __\\ \\  \\ \\  \\\\ \\  \\  \r\n        \\ \\  \\____\\ \\  \\\\\\  \\ \\  \\|\\  \\ \\  \\ \\  \\\\ \\  \\ \r\n         \\ \\_______\\ \\_______\\ \\_______\\ \\__\\ \\__\\\\ \\__\\\r\n          \\|_______|\\|_______|\\|_______|\\|__|\\|__| \\|__|");

                tempUserData.SetAllUserData();

                this.validationData = uatoolkits.UserDataValidator(tempUserData);

                if (this.validationData)
                {
                    this.findUser = uatoolkits.FindUserAccount(tempUserData)[0];

                    if (this.findUser)
                    {
                        fonts.GreenText($"Welcome, {tempUserData.Name}");
                        fonts.GreenText("Press any key to continue...", true);
                        
                        tempUserData.Role = uatoolkits.FindUserAccount(tempUserData)[1];

                        this.userData = tempUserData;
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
            UserStruct tempUserData = new UserStruct();

            while(!this.validationData)
            {
                Console.Clear();
                Console.WriteLine("        ________  ________  _______   ________  _________  ___  ________   ________     \r\n       |\\   ____\\|\\   __  \\|\\  ___ \\ |\\   __  \\|\\___   ___\\\\  \\|\\   ___  \\|\\   ____\\    \r\n       \\ \\  \\___|\\ \\  \\|\\  \\ \\   __/|\\ \\  \\|\\  \\|___ \\  \\_\\ \\  \\ \\  \\\\ \\  \\ \\  \\___|    \r\n        \\ \\  \\    \\ \\   _  _\\ \\  \\_|/_\\ \\   __  \\   \\ \\  \\ \\ \\  \\ \\  \\\\ \\  \\ \\  \\  ___  \r\n         \\ \\  \\____\\ \\  \\\\  \\\\ \\  \\_|\\ \\ \\  \\ \\  \\   \\ \\  \\ \\ \\  \\ \\  \\\\ \\  \\ \\  \\|\\  \\ \r\n          \\ \\_______\\ \\__\\\\ _\\\\ \\_______\\ \\__\\ \\__\\   \\ \\__\\ \\ \\__\\ \\__\\\\ \\__\\ \\_______\\\r\n           \\|_______|\\|__|\\|__|\\|_______|\\|__|\\|__|    \\|__|  \\|__|\\|__| \\|__|\\|_______|\r\n        ________  ________  ________  ________  ___  ___  ________   _________          \r\n       |\\   __  \\|\\   ____\\|\\   ____\\|\\   __  \\|\\  \\|\\  \\|\\   ___  \\|\\___   ___\\        \r\n       \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\|___ \\  \\_|        \r\n        \\ \\   __  \\ \\  \\    \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\         \r\n         \\ \\  \\ \\  \\ \\  \\____\\ \\  \\____\\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\        \r\n          \\ \\__\\ \\__\\ \\_______\\ \\_______\\ \\_______\\ \\_______\\ \\__\\\\ \\__\\   \\ \\__\\       \r\n           \\|__|\\|__|\\|_______|\\|_______|\\|_______|\\|_______|\\|__| \\|__|    \\|__|       ");
                fonts.OrangeText("The name must not include special characters.\r\n\t\t    The minimum password length is 6 characters.");

                tempUserData.SetAllUserData();
                Console.Write("\t\t    Confirm password:");
                confPassword = Console.ReadLine() ?? "";


                if (uatoolkits.UserDataValidator(tempUserData) && tempUserData.Password.Equals(confPassword))
                {
                    UserStruct newUser = tempUserData;
                    if(uatoolkits.CreateAccount(newUser))
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

        public void EditUserAccount(UserStruct userData)
        {
            UserStruct newUserData = new UserStruct();
            bool accountInformationUpdated = false;

            while(!accountInformationUpdated)
            {
                Console.Clear();
                Console.WriteLine("            _______   ________  ___  _________                                       \r\n       |\\  ___ \\ |\\   ___ \\|\\  \\|\\___   ___\\                                     \r\n       \\ \\   __/|\\ \\  \\_|\\ \\ \\  \\|___ \\  \\_|                                     \r\n        \\ \\  \\_|/_\\ \\  \\ \\\\ \\ \\  \\   \\ \\  \\                                      \r\n         \\ \\  \\_|\\ \\ \\  \\_\\\\ \\ \\  \\   \\ \\  \\                                     \r\n          \\ \\_______\\ \\_______\\ \\__\\   \\ \\__\\                                    \r\n           \\|_______|\\|_______|\\|__|    \\|__|                                    \r\n        ________  ________  ________  ________  ___  ___  ________   _________   \r\n       |\\   __  \\|\\   ____\\|\\   ____\\|\\   __  \\|\\  \\|\\  \\|\\   ___  \\|\\___   ___\\ \r\n       \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\|___ \\  \\_| \r\n        \\ \\   __  \\ \\  \\    \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\  \r\n         \\ \\  \\ \\  \\ \\  \\____\\ \\  \\____\\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\ \r\n          \\ \\__\\ \\__\\ \\_______\\ \\_______\\ \\_______\\ \\_______\\ \\__\\\\ \\__\\   \\ \\__\\\r\n           \\|__|\\|__|\\|_______|\\|_______|\\|_______|\\|_______|\\|__| \\|__|    \\|__|");
                fonts.OrangeText("\n\t\t    Old account information:");
                userData.GetAllUserData();
                fonts.OrangeText("\n\t\t    Write new account information:");
                newUserData.SetAllUserData();
                newUserData.Role = userData.Role;

                if(!uatoolkits.FindUserAccount(newUserData)[0] && uatoolkits.UserDataValidator(newUserData))
                {
                    uatoolkits.DeleteAccount(this.userData);
                    uatoolkits.CreateAccount(newUserData);
                    this.userData = newUserData;
                    this.userData.Role = newUserData.Role;

                    fonts.GreenText("A C C O U N T   I N F O R M A T I O N   H A S   B E E N   U P D A T E D");
                    fonts.GreenText("Press any key to continue...", true);
                    accountInformationUpdated = true;
                }
                else
                {
                    fonts.RedText("E R R O R   U P D A T I N G   I N F O R M A T I O N");
                    fonts.OrangeText("Press any key to try again...", true);
                }
            }
        }

        public void CheckAccount()
        {
            Console.Clear();
            Console.WriteLine("        ___  ___  ________  _______   ________                                   \r\n       |\\  \\|\\  \\|\\   ____\\|\\  ___ \\ |\\   __  \\                                  \r\n       \\ \\  \\\\\\  \\ \\  \\___|\\ \\   __/|\\ \\  \\|\\  \\                                 \r\n        \\ \\  \\\\\\  \\ \\_____  \\ \\  \\_|/_\\ \\   _  _\\                                \r\n         \\ \\  \\\\\\  \\|____|\\  \\ \\  \\_|\\ \\ \\  \\\\  \\|                               \r\n          \\ \\_______\\____\\_\\  \\ \\_______\\ \\__\\\\ _\\                               \r\n           \\|_______|\\_________\\|_______|\\|__|\\|__|                              \r\n        ________  __________________  ________  ___  ___  ________   _________   \r\n       |\\   __  \\|\\   ____\\|\\   ____\\|\\   __  \\|\\  \\|\\  \\|\\   ___  \\|\\___   ___\\ \r\n       \\ \\  \\|\\  \\ \\  \\___|\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\|___ \\  \\_| \r\n        \\ \\   __  \\ \\  \\    \\ \\  \\    \\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\  \r\n         \\ \\  \\ \\  \\ \\  \\____\\ \\  \\____\\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\   \\ \\  \\ \r\n          \\ \\__\\ \\__\\ \\_______\\ \\_______\\ \\_______\\ \\_______\\ \\__\\\\ \\__\\   \\ \\__\\\r\n           \\|__|\\|__|\\|_______|\\|_______|\\|_______|\\|_______|\\|__| \\|__|    \\|__|");
            this.userData.GetAllUserData();

            List<string> accountMenu = [
                                        "Edit account",
                                        "Exit"
                                    ];
            toolkits.DisplayMenuList(accountMenu);
            byte input = toolkits.CheckUserInput();

            switch(input)
            {
                case 1:
                    EditUserAccount(this.userData);
                    
                    break;
                case 2:
                    Menu();
                    break;
            }
        }

        public void FindProduct(String options)
        {
            
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
    
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("       _____ ______   _______   ________   ___  ___     \r\n      |\\   _ \\  _   \\|\\  ___ \\ |\\   ___  \\|\\  \\|\\  \\    \r\n      \\ \\  \\\\\\__\\ \\  \\ \\   __/|\\ \\  \\\\ \\  \\ \\  \\\\\\  \\   \r\n       \\ \\  \\\\|__| \\  \\ \\  \\_|/_\\ \\  \\\\ \\  \\ \\  \\\\\\  \\  \r\n        \\ \\  \\    \\ \\  \\ \\  \\_|\\ \\ \\  \\\\ \\  \\ \\  \\\\\\  \\ \r\n         \\ \\__\\    \\ \\__\\ \\_______\\ \\__\\\\ \\__\\ \\_______\\\r\n          \\|__|     \\|__|\\|_______|\\|__| \\|__|\\|_______|");
            Console.WriteLine($"\n\t\t    C U R R E N T   U S E R: {this.userData.Name}");
            Console.WriteLine($"\t\t    R O L E: {(this.userData.Role ? "Admin" : "Normal user")}");
            List<string> listNormalUser = [
                                    "Check account",          // Created
                                    "Find product",
                                    "About program",          // Created
                                    "Exit"                    // Created
                                        ];
            List<string> listAdminUser = [
                                    "Check account",
                                    "Find product",
                                    "About program",
                                    "Products control menu",
                                    "Users control menu",
                                    "Exit"
                                        ];
            toolkits.DisplayMenuList(this.userData.Role ? listAdminUser : listNormalUser);
        }
    }
}
