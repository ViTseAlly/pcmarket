using System.Globalization;
using System.Security.Cryptography.X509Certificates;
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
        public List<string> PusharedProducts { get; set; }

        [JsonConstructor]
        public UserStruct( string name, string surname, string email, string password, List<string> pusharedProducts, bool role = false)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Role = role;
            PusharedProducts = pusharedProducts ?? new List<string>();
        }

        public void GetAllUserData()
        {
            Console.WriteLine($"\n\t\t    User name: {this.Name}");
            Console.WriteLine($"\t\t    Surname: {this.Surname}");
            Console.WriteLine($"\t\t    Email: {this.Email}");
            Console.WriteLine($"\t\t    Password: {this.Password}");
            Console.WriteLine($"\t\t    Status: {(this.Role ? "Admin" : "Normal user")}");
            Console.WriteLine($"\t\t    Pushared products:");

            if (PusharedProducts == null || PusharedProducts.Count == 0)
            {
                Console.WriteLine("\t\t      No pushares.");
            }
            else
            {
                foreach (string el in PusharedProducts)
                {
                    Console.WriteLine($"\t\t     - {el}");
                }
            }
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
