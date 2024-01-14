using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;



namespace App.Toolkit
{
    public class Tokens
    {
        private readonly string SECRET_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJTRUNSRVRfS0VZIn0.OUdJdTxDzSWeDXf7uuUrUQiIh3LqvyfM6xv5picwopM";

        public string EncodePassword(string password)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( this.SECRET_KEY ));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] { new Claim("password", password) };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}