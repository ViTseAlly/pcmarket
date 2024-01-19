using App.Toolkit;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;




namespace App.Structs
{
    public struct UserStruct
    {
        Fonts fonts = new Fonts();
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
            Name = Console.ReadLine() ?? "";
            Console.Write("\n\t\t    Surname:");
            Surname = Console.ReadLine() ?? "";
            Console.Write("\n\t\t    Email:");
            Email = Console.ReadLine() ?? "";
            Console.Write("\n\t\t    Password:");
            Password = GenerateJwtToken(Console.ReadLine() ?? "", "uwinfywhiyhfzwu65f7wcgfni6rgixr6tfn8e7rznf76gfz76n");
        }

        public string GenerateJwtToken(string data, string TOKEN)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(TOKEN));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim("data", data) },
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public bool EqualsTwoUsers(UserStruct userData)
        {
            return Name.Equals(userData.Name, StringComparison.OrdinalIgnoreCase) &&
               Surname.Equals(userData.Surname, StringComparison.OrdinalIgnoreCase) &&
               Password.Equals(userData.Password) &&
               Email.Equals(userData.Email, StringComparison.OrdinalIgnoreCase);
        }
    }
}
