using Newtonsoft.Json;


namespace App.Structs
{
    public struct UserStruct
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Role { get; private set; }

        [JsonConstructor]
        public UserStruct(string name, string surname, string email, string password, bool role)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
