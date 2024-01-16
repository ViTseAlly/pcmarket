using App.UI;
using App.Toolkit;
using App.Structs;



namespace Project
{
    class Program
    {
        private static Toolkits toolkits = new Toolkits();                                       //    Створення допоміжного о'бєкту у якому містяться основні функції проекту
        private static Interfaces interfaces = new Interfaces();                                 //    Створення об'єкту що відповідальний за відображенння "сторінок" у консолі
        private static UserStruct user = new UserStruct();

        public static void Main(string[] args)
        {                                                                             // Оголошення власних об'єктів:
            bool programStart = true;
            bool isUserLogged = false;

            interfaces.Start();                                                       // Початок роботи програми: Запуск основного меню

            while (!isUserLogged && programStart)                                     // Цикл який буде діяти поки користувач не увійде у акаунт або не вийде з програми
            {
                byte userInput = toolkits.CheckUserInput();
                switch (userInput)
                {
                    case 1:
                        user = interfaces.Login();                               // Визов вікна входу у акаунт
                        isUserLogged = true;                                          // Зміна прапору на true (перевірка у циклі)
                        break;
                    case 2:
                        interfaces.CreateAccount();                                   // Вікно створення акаунту
                        interfaces.Start();                                           // Після успішного створення користувача поверне на головний екран
                        break;
                    case 3:
                        programStart = false;                                         // Зміна прапору на false (перевірка у циклі)
                        interfaces.Exit();                                            // Завершення програми виводом вікна виходу
                        break;
                }
            }

            while (isUserLogged && programStart)                                      // Цикл для запуску основного функціоналу програми після того як користувач увійде у акаунт
            {
                interfaces.Menu();                                            // Запуск вікна головного меню
                byte userInput = toolkits.CheckUserInput();
                if(user.Role)
                {
                    switch(userInput)
                    {
                        case 1:
                            interfaces.CheckAccount();
                            break;
                        case 3:
                            interfaces.About();
                            interfaces.Menu();
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
