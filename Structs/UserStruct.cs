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
        public UserStruct( string name, string surname, string email, string password, bool role = false)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Role = role;
        }

        public void GetAllUserData()
        {
            Console.WriteLine($"\n\t\t    User name: {this.Name}");
            Console.WriteLine($"\t\t    Surname: {this.Surname}");
            Console.WriteLine($"\t\t    Email: {this.Email}");
            Console.WriteLine($"\t\t    Password: {this.Password}");
            Console.WriteLine($"\t\t    Status: {(this.Role ? "Admin" : "Normal user")}");
        }

        public void SetAllUserData()
        {
            Console.Write("\n\t\t    Name:");
            this.Name = Console.ReadLine() ?? "";
            Console.Write("\n\t\t    Surname:");
            this.Surname = Console.ReadLine() ?? "";
            Console.Write("\n\t\t    Email:");
            this.Email = Console.ReadLine() ?? "";
            Console.Write("\n\t\t    Password:");
            this.Password = Console.ReadLine() ?? "";
        }

    }
}
