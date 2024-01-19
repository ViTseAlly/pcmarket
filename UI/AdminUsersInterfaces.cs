using App.Path;
using App.Structs;
using App.Toolkit;



namespace App.UI
{
    public class AdminUsersInterfaces
    {
        Toolkits toolkits = new Toolkits();
        UserAccountToolkits uatoolkits = new UserAccountToolkits();
        Fonts fonts = new Fonts();
        PathToFiles pathToFiles = new PathToFiles();

        public void GetAllUserAccounts()
        {
            List<UserStruct> usersList = toolkits.GetDataFromUsersJsonFile(pathToFiles.GetPathToUsers());
            foreach(UserStruct user in usersList)
            {
                user.GetAllUserData();
            }
            fonts.GreenText("Press any key to leave...", true);
        }

        public void CreateNewUserAccount()
        {
            bool accountCreated = false;
            Console.Clear();
            Console.WriteLine("        ________    _______    ___       __                                            \r\n       |\\   ___  \\ |\\  ___ \\  |\\  \\     |\\  \\                                          \r\n       \\ \\  \\\\ \\  \\\\ \\   __/| \\ \\  \\    \\ \\  \\                                         \r\n        \\ \\  \\\\ \\  \\\\ \\  \\_|/__\\ \\  \\  __\\ \\  \\                                        \r\n         \\ \\  \\\\ \\  \\\\ \\  \\_|\\ \\\\ \\  \\|\\__\\_\\  \\                                       \r\n          \\ \\__\\\\ \\__\\\\ \\_______\\\\ \\____________\\                                      \r\n           \\|__| \\|__| \\|_______| \\|____________|                                      \r\n        ________   ________   ________   ________   ___  ___   ________    _________   \r\n       |\\   __  \\ |\\   ____\\ |\\   ____\\ |\\   __  \\ |\\  \\|\\  \\ |\\   ___  \\ |\\___   ___\\ \r\n       \\ \\  \\|\\  \\\\ \\  \\___| \\ \\  \\___| \\ \\  \\|\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\\\|___ \\  \\_| \r\n        \\ \\   __  \\\\ \\  \\     \\ \\  \\     \\ \\  \\\\\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\    \\ \\  \\  \r\n         \\ \\  \\ \\  \\\\ \\  \\____ \\ \\  \\____ \\ \\  \\\\\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\    \\ \\  \\ \r\n          \\ \\__\\ \\__\\\\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\__\\\\ \\__\\    \\ \\__\\\r\n           \\|__|\\|__| \\|_______| \\|_______| \\|_______| \\|_______| \\|__| \\|__|     \\|__|");
            
            while(!accountCreated)
            {
                Console.WriteLine("\n\t\t    Write new user information:");
                fonts.OrangeText("The nickname must not contain special characters.\n\t\t    The minimum password length is 6 characters.");
                UserStruct newUser = new UserStruct();
                newUser.SetAllUserData();
                Console.Write("\n\t\t    Confirm password:");
                string confPassword = newUser.GenerateJwtToken(Console.ReadLine() ?? "", "uwinfywhiyhfzwu65f7wcgfni6rgixr6tfn8e7rznf76gfz76n");

                if(uatoolkits.UserDataValidator(newUser) && newUser.Password == confPassword)
                {
                    if(uatoolkits.CreateAccount(newUser))
                    {
                        accountCreated = true;
                        fonts.GreenText("A C C O U N T   C R E A T E D");
                        fonts.GreenText("Press any key for leave...", true);
                    }
                    else
                    {
                        fonts.RedText("C R E A T I N G   A C C O U N T   E R R O R. T R Y   A G A I N");
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
    
        public void EditUserAccount()
        {
            bool accountInformationUpdated = false;
            Console.Clear();
            Console.WriteLine("        _______    ________   ___   _________   ___   ________    ________             \r\n       |\\  ___ \\  |\\   ___ \\ |\\  \\ |\\___   ___\\|\\  \\ |\\   ___  \\ |\\   ____\\            \r\n       \\ \\   __/| \\ \\  \\_|\\ \\\\ \\  \\\\|___ \\  \\_|\\ \\  \\\\ \\  \\\\ \\  \\\\ \\  \\___|            \r\n        \\ \\  \\_|/__\\ \\  \\ \\\\ \\\\ \\  \\    \\ \\  \\  \\ \\  \\\\ \\  \\\\ \\  \\\\ \\  \\  ___          \r\n         \\ \\  \\_|\\ \\\\ \\  \\_\\\\ \\\\ \\  \\    \\ \\  \\  \\ \\  \\\\ \\  \\\\ \\  \\\\ \\  \\|\\  \\         \r\n          \\ \\_______\\\\ \\_______\\\\ \\__\\    \\ \\__\\  \\ \\__\\\\ \\__\\\\ \\__\\\\ \\_______\\        \r\n           \\|_______| \\|_______| \\|__|     \\|__|   \\|__| \\|__| \\|__| \\|_______|        \r\n        ________   ________   ________   ________   ___  ___   ________    _________   \r\n       |\\   __  \\ |\\   ____\\ |\\   ____\\ |\\   __  \\ |\\  \\|\\  \\ |\\   ___  \\ |\\___   ___\\ \r\n       \\ \\  \\|\\  \\\\ \\  \\___| \\ \\  \\___| \\ \\  \\|\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\\\|___ \\  \\_| \r\n        \\ \\   __  \\\\ \\  \\     \\ \\  \\     \\ \\  \\\\\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\    \\ \\  \\  \r\n         \\ \\  \\ \\  \\\\ \\  \\____ \\ \\  \\____ \\ \\  \\\\\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\    \\ \\  \\ \r\n          \\ \\__\\ \\__\\\\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\__\\\\ \\__\\    \\ \\__\\\r\n           \\|__|\\|__| \\|_______| \\|_______| \\|_______| \\|_______| \\|__| \\|__|     \\|__|");
            Console.WriteLine("\n\t\t    Find user:");
            UserStruct findUser = new UserStruct();
            UserStruct newUser = new UserStruct();
            findUser.SetAllUserData();
            if(uatoolkits.UserDataValidator(findUser) && uatoolkits.FindUserAccount(findUser)[0])
            {
                while(!accountInformationUpdated)
                {
                    fonts.GreenText("Write new user account information:");
                    newUser.SetAllUserData();
                    if(uatoolkits.UserDataValidator(newUser) && !uatoolkits.FindUserAccount(newUser)[0])
                    {
                        newUser.Role = findUser.Role;
                        newUser.PusharedProducts = findUser.PusharedProducts;
                        if(uatoolkits.DeleteAccount(findUser))
                        {
                            uatoolkits.CreateAccount(newUser);
                            accountInformationUpdated = true;
                            fonts.GreenText("A C C O U N T   I N F O R M A T I O N   U P D A T E D");
                            fonts.GreenText("Press any key to leave in admin menu...", true);
                        }
                    }
                    else
                    {
                        fonts.RedText("E R R O R   U P D A T E   I N F O R M A T I O N");
                        fonts.OrangeText("Press any key to try again...", true);
                    }
                }
            }
            else
            {
                fonts.RedText("A C C O U N T   N O T   F I N D");
                fonts.OrangeText("Press any key to leave in admin menu...", true);
            }
        }
    
        public void DeleteUserAccount()
        {
            bool accountDeleted = false;
            while(!accountDeleted)
            {
                Console.Clear();
                Console.WriteLine("        ________   _______    ___        _______   _________   _______                 \r\n       |\\   ___ \\ |\\  ___ \\  |\\  \\      |\\  ___ \\ |\\___   ___\\|\\  ___ \\                \r\n       \\ \\  \\_|\\ \\\\ \\   __/| \\ \\  \\     \\ \\   __/|\\|___ \\  \\_|\\ \\   __/|               \r\n        \\ \\  \\ \\\\ \\\\ \\  \\_|/__\\ \\  \\     \\ \\  \\_|/__   \\ \\  \\  \\ \\  \\_|/__             \r\n         \\ \\  \\_\\\\ \\\\ \\  \\_|\\ \\\\ \\  \\____ \\ \\  \\_|\\ \\   \\ \\  \\  \\ \\  \\_|\\ \\            \r\n          \\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\_______\\   \\ \\__\\  \\ \\_______\\           \r\n           \\|_______| \\|_______| \\|_______| \\|_______|    \\|__|   \\|_______|           \r\n        ________   ________   ________   ________   ___  ___   ________    _________   \r\n       |\\   __  \\ |\\   ____\\ |\\   ____\\ |\\   __  \\ |\\  \\|\\  \\ |\\   ___  \\ |\\___   ___\\ \r\n       \\ \\  \\|\\  \\\\ \\  \\___| \\ \\  \\___| \\ \\  \\|\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\\\|___ \\  \\_| \r\n        \\ \\   __  \\\\ \\  \\     \\ \\  \\     \\ \\  \\\\\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\    \\ \\  \\  \r\n         \\ \\  \\ \\  \\\\ \\  \\____ \\ \\  \\____ \\ \\  \\\\\\  \\\\ \\  \\\\\\  \\\\ \\  \\\\ \\  \\    \\ \\  \\ \r\n          \\ \\__\\ \\__\\\\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\__\\\\ \\__\\    \\ \\__\\\r\n           \\|__|\\|__| \\|_______| \\|_______| \\|_______| \\|_______| \\|__| \\|__|     \\|__|");
                Console.WriteLine("\n\t\t    Find user account:");
                UserStruct findUser = new UserStruct();
                findUser.SetAllUserData();
                if(uatoolkits.FindUserAccount(findUser)[0] && uatoolkits.UserDataValidator(findUser))
                {
                    if(uatoolkits.DeleteAccount(findUser))
                    {
                        accountDeleted = true;
                        fonts.GreenText("U S E R   A C C O U N T  D E L E T E D");
                        fonts.GreenText("Press any key to leave in admin menu...", true);
                    }
                    else
                    {
                        fonts.RedText("U S E R   N O T   F I N D");
                        fonts.OrangeText("Press any key to try again...", true);
                    }
                }
                else
                {
                    fonts.RedText("U S E R   N O T   F I N D");
                    fonts.OrangeText("Press any key to try again...", true);
                }
            }
        }
    }
}
