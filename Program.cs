using App.UI;
using App.Toolkit;
using App.Structs;



namespace Project
{
    class Program
    {
        private static Toolkits toolkits = new Toolkits();                                     
        private static Interfaces interfaces = new Interfaces();                                
        private static UserStruct user = new UserStruct();

        public static void Main(string[] args)
        {                                                                    
            bool programStart = true;
            bool isUserLogged = false;

            interfaces.Start();                                                 
            while (!isUserLogged && programStart)                                  
            {
                byte userInput = toolkits.CheckUserInput();
                switch (userInput)
                {
                    case 1:
                        user = interfaces.Login();                            
                        isUserLogged = true;                                  
                        break;
                    case 2:
                        interfaces.CreateAccount();                                 
                        interfaces.Start();                                         
                        break;
                    case 3:
                        programStart = false;                                        
                        interfaces.Exit();                                           
                        break;
                }
            }

            while (isUserLogged && programStart)                                     
            {
                interfaces.Menu();                                            
                byte userInput = toolkits.CheckUserInput();
                if(user.Role)
                {
                    switch(userInput)
                    {
                        case 1:
                            interfaces.CheckAccount();
                            break;
                        case 2:
                            interfaces.FindProduct();
                            interfaces.Menu();
                            break;
                        case 3:
                            interfaces.About();
                            interfaces.Menu();
                            break;
                        case 4:
                            interfaces.AdminMenuProducts();
                            break;
                        case 5:
                            interfaces.AdminMenuUsers();
                            break;
                        case 6:
                            programStart = false;
                            interfaces.Exit();
                            break;
                    }
                }
                else
                {
                    switch(userInput)
                    {
                        case 1:
                            interfaces.CheckAccount();
                            break;
                        case 2:
                            interfaces.FindProduct();
                            interfaces.Menu();
                            break;
                        case 3:
                            interfaces.About();
                            interfaces.Menu();
                            break;
                        case 4:
                            programStart = false;
                            interfaces.Exit();
                            break;
                    }
                }
            }
        }
    }
}
