using Newtonsoft.Json;
using App.Structs;


namespace App.Toolkit
{
    internal class Toolkits
    {
        private HashSet<char> badCharacters = new HashSet<char> { '\n', '\t', '#', '!', '%', '^', '*', '?', '/', '\\', '.', ',', '+' };
        private HashSet<char> badEmailCharacters = new HashSet<char> { ' ', '\n', ',', '!', '#', '\\', '/', '|', '!', '%', '^', '*', '?' };
        private Fonts fonts = new Fonts();
        private string PATH_TO_FILE = "./Data/Users/users.json";


        public bool UserDataValidator(string name, string surname, string email, string password)
        {
            bool nameValidation = name.Any(c => this.badCharacters.Contains(c));
            bool surnameValidation = surname.Any(c => this.badCharacters.Contains(c));
            bool emailValidation = email.Any(c => this.badEmailCharacters.Contains(c));
            bool passwordValidation = password.Length > 6;

            bool isEmailValid = !emailValidation && email.Contains('@');

            return !(nameValidation || surnameValidation || !isEmailValid || !passwordValidation);
        }

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

        public bool FindUserAccount(UserStruct user, UserStruct userData)
        {
            return user.Name.Equals(userData.Name, StringComparison.OrdinalIgnoreCase) &&
               user.Surname.Equals(userData.Surname, StringComparison.OrdinalIgnoreCase) &&
               user.Password.Equals(userData.Password) &&
               user.Email.Equals(userData.Email, StringComparison.OrdinalIgnoreCase);
        }

        public bool LoginHandler(string username, string surname, string email, string password)
        {
            List<UserStruct> userList = GetDataFromJsonFile(PATH_TO_FILE);

            UserStruct userData = new UserStruct(username, surname, email, password, false);
            foreach (UserStruct user in userList)
            {
                if(FindUserAccount(user, userData)) return FindUserAccount(user, userData);
            }
            return false;
        }

        public bool CheckUserRole(string name, string surname, string email, string password)
        {
            List<UserStruct> userList = GetDataFromJsonFile(PATH_TO_FILE);
            UserStruct userData = new UserStruct(name, surname, email, password, false);

            foreach (UserStruct user in userList)
            {
                if (FindUserAccount(user, userData))
                {
                    return user.Role;
                }
            }

            return false;
        }

        private List<UserStruct> GetDataFromJsonFile(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            List<UserStruct> userList = JsonConvert.DeserializeObject<List<UserStruct>>(jsonContent);

            return userList ?? new List<UserStruct>();
        }

        public bool CreateAccount(UserStruct newUser)
        {
            List<UserStruct> userList = GetDataFromJsonFile(PATH_TO_FILE);

            foreach (UserStruct user in userList)
            {
                if (FindUserAccount(user, newUser))
                {
                    return false;
                }
            }

            userList.Add(newUser);

            string jsonContent = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(PATH_TO_FILE, jsonContent);

            return true;
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
