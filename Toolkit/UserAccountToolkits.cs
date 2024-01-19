using App.Structs;
using Newtonsoft.Json;
using App.Path;




namespace App.Toolkit
{
    public class UserAccountToolkits
    {
        private HashSet<char> badCharacters = new HashSet<char> { '\n', '\t', '#', '!', '%', '^', '*', '?', '/', '\\', '.', ',', '+' };
        private HashSet<char> badEmailCharacters = new HashSet<char> { ' ', '\n', ',', '!', '#', '\\', '/', '|', '!', '%', '^', '*', '?' };
        Toolkits toolkits = new Toolkits();
        Fonts fonts = new Fonts();
        PathToFiles pathToFile = new PathToFiles();

        public bool CreateAccount(UserStruct newUser)
        {
            List<UserStruct> userList = toolkits.GetDataFromUsersJsonFile(pathToFile.GetPathToUsers());
            if(FindUserAccount(newUser)[0])
            {
                return false;
            }

            userList.Add(newUser);

            string jsonContent = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(pathToFile.GetPathToUsers(), jsonContent);

            return true;
        }

        public bool DeleteAccount(UserStruct userData)
        {
            List<UserStruct> usersList = toolkits.GetDataFromUsersJsonFile(pathToFile.GetPathToUsers());

            for (int i = 0; i < usersList.Count; i++)
            {
                if (string.Equals(usersList[i].Name, userData.Name, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(usersList[i].Surname, userData.Surname, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(usersList[i].Email, userData.Email, StringComparison.OrdinalIgnoreCase))
                {
                    usersList.RemoveAt(i);
                    File.Delete(pathToFile.GetPathToUsers());
                    string jsonContent = JsonConvert.SerializeObject(usersList, Formatting.Indented);
                    File.WriteAllText(pathToFile.GetPathToUsers(), jsonContent);
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
            List<UserStruct> userList = toolkits.GetDataFromUsersJsonFile(pathToFile.GetPathToUsers());

            foreach(UserStruct user in userList)
            {
                if(userData.EqualsTwoUsers(user))
                {
                    return new bool[] {true, user.Role};
                }
            }
            return new bool[] {false, false};
        }
    
        public List<string> GetPusharedProducts(UserStruct userData)
        {
            List<UserStruct> usersList = toolkits.GetDataFromUsersJsonFile(pathToFile.GetPathToUsers());
            foreach(UserStruct user in usersList)
            {
                if(userData.EqualsTwoUsers(user))
                {
                    return user.PusharedProducts;
                }
            }
            return new List<string>();
        }
            
        public bool InsertProductInFile(UserStruct userData, ProductStruct productData)
        {
            List<UserStruct> userList = toolkits.GetDataFromUsersJsonFile(pathToFile.GetPathToUsers());

            foreach(UserStruct user in userList)
            {
                if(userData.EqualsTwoUsers(user))
                {
                    user.PusharedProducts.Add($"Id: {productData.Id};Type: {productData.Type};Name: {productData.Name};Price: {productData.Price};Description: {productData.Information}");
                    string jsonContent = JsonConvert.SerializeObject(userList, Formatting.Indented);
                    File.WriteAllText(pathToFile.GetPathToUsers(), jsonContent);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteProductInFile(UserStruct userData, int productId)
        {
            List<UserStruct> userList = toolkits.GetDataFromUsersJsonFile(pathToFile.GetPathToUsers());

            foreach (UserStruct user in userList)
            {
                if (userData.EqualsTwoUsers(user))
                {
                    int index = user.PusharedProducts.FindIndex(p => p.Contains($"Id: {productId};"));

                    if (index != -1)
                    {
                        user.PusharedProducts.RemoveAt(index);

                        string jsonContent = JsonConvert.SerializeObject(userList, Formatting.Indented);
                        File.WriteAllText(pathToFile.GetPathToUsers(), jsonContent);

                        return true;
                    }
                }
            }

            return false;
        }
    }
}