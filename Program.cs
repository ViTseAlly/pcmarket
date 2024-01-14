using App.UI;
using App.Toolkit;
using App.User;


namespace Project
{
    class Program
    {
        public static void Main(string[] args)
        {                                                                             // Оголошення власних об'єктів:
            Toolkits toolkits = new Toolkits();                                       //    Створення допоміжного о'бєкту у якому містяться основні функції проекту
            Interfaces interfaces = new Interfaces();                                 //    Створення об'єкту що відповідальний за відображенння "сторінок" у консолі
            User user;                                                                //    Створення користувача

            bool programStart = true;
            bool isUserLogged = false;

            interfaces.Start();                                                       // Початок роботи програми: Запуск основного меню

            while (!isUserLogged && programStart)                                     // Цикл який буде діяти поки користувач не увійде у акаунт або не вийде з програми
            {
                byte userInput = toolkits.CheckUserInput();
                switch (userInput)
                {
                    case 1:
                        user = new User(interfaces.Login());                          // Визов вікна входу у акаунт
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
                interfaces.Menu();                                                    // Запуск вікга головного меню
                byte userInput = toolkits.CheckUserInput();
            }
        }
    }
}
