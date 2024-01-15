using Newtonsoft.Json;


namespace App.Structs
{
    public struct UserStruct
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }

        [JsonConstructor]
        public UserStruct(string name, string surname, string email, string password, bool role = false)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
