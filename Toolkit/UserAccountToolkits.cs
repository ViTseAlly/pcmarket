using App.Structs;
using Newtonsoft.Json;



namespace App.Toolkit
{
    public class UserAccountToolkits
    {
        private HashSet<char> badCharacters = new HashSet<char> { '\n', '\t', '#', '!', '%', '^', '*', '?', '/', '\\', '.', ',', '+' };
        private HashSet<char> badEmailCharacters = new HashSet<char> { ' ', '\n', ',', '!', '#', '\\', '/', '|', '!', '%', '^', '*', '?' };
        Toolkits toolkits = new Toolkits();
        Fonts fonts = new Fonts();
        private string PATH_TO_USERS_FILE = "./Data/Users/users.json";

        public bool CreateAccount(UserStruct newUser)
        {
            List<UserStruct> userList = toolkits.GetDataFromUsersJsonFile(this.PATH_TO_USERS_FILE);
            if(FindUserAccount(newUser)[0])
            {
                return false;
            }

            userList.Add(newUser);

            string jsonContent = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(this.PATH_TO_USERS_FILE, jsonContent);

            return true;
        }

        public bool DeleteAccount(UserStruct userData)
        {
            List<UserStruct> usersList = toolkits.GetDataFromUsersJsonFile(this.PATH_TO_USERS_FILE);

            for (int i = 0; i < usersList.Count; i++)
            {
                if (string.Equals(usersList[i].Name, userData.Name, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(usersList[i].Surname, userData.Surname, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(usersList[i].Email, userData.Email, StringComparison.OrdinalIgnoreCase))
                {
                    usersList.RemoveAt(i);
                    File.Delete(this.PATH_TO_USERS_FILE);
                    string jsonContent = JsonConvert.SerializeObject(usersList, Formatting.Indented);
                    File.WriteAllText(this.PATH_TO_USERS_FILE, jsonContent);
                    return true;
                }
            }

            return false; 
        }
    
        public bool UserDataValidator(UserStruct userData)
        {
            bool nameValidation = userData.Name.Any(c => this.badCharacters.Contains(c));
            bool surnameValidation = userData.Surname.Any(c => this.badCharacters.Contains(c));
            bool emailValidation = userData.Email.Any(c => this.badEmailCharacters.Contains(c));
            bool passwordValidation = userData.Password.Length > 6;

            bool isEmailValid = !emailValidation && userData.Email.Contains('@');

            return !(nameValidation || surnameValidation || !isEmailValid || !passwordValidation);
        }
    
        public bool[] FindUserAccount(UserStruct userData)
        {
            List<UserStruct> userList = toolkits.GetDataFromUsersJsonFile(this.PATH_TO_USERS_FILE);

            foreach(UserStruct user in userList)
            {
                if(user.Name.Equals(userData.Name, StringComparison.OrdinalIgnoreCase) &&
               user.Surname.Equals(userData.Surname, StringComparison.OrdinalIgnoreCase) &&
               user.Password.Equals(userData.Password) &&
               user.Email.Equals(userData.Email, StringComparison.OrdinalIgnoreCase))
               {
                return new bool[] {true, user.Role};
               }
            }
            return new bool[] {false, false};
        }
    
        public List<string> GetPusharedProducts(UserStruct userData)
        {
            List<UserStruct> usersList = toolkits.GetDataFromUsersJsonFile(this.PATH_TO_USERS_FILE);
            foreach(UserStruct user in usersList)
            {
                 if(user.Name.Equals(userData.Name, StringComparison.OrdinalIgnoreCase) &&
               user.Surname.Equals(userData.Surname, StringComparison.OrdinalIgnoreCase) &&
               user.Password.Equals(userData.Password) &&
               user.Email.Equals(userData.Email, StringComparison.OrdinalIgnoreCase))
               {
                return user.PusharedProducts;
               }
            }
            return new List<string>();
        }
            
        public bool InsertProductInFile(UserStruct userData, ProductStruct productData)
        {
            List<UserStruct> userList = toolkits.GetDataFromUsersJsonFile(this.PATH_TO_USERS_FILE);

            UserStruct userToUpdate = userList.FirstOrDefault(u =>
                string.Equals(u.Name, userData.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(u.Surname, userData.Surname, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(u.Email, userData.Email, StringComparison.OrdinalIgnoreCase));

            userToUpdate.PusharedProducts.Add(productData.Name);
            string jsonContent = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(this.PATH_TO_USERS_FILE, jsonContent);
            return true;
        }

    }
}