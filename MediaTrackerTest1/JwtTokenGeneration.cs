using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace MediaTrackerTest1
{
    class JwtTokenGeneration

    {
        public string GenerateToken(int ID)
        {

            AppUserService AppUser = new AppUserService();

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("This is a test key that is generated"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var securityTokenDescriptor = new SecurityTokenDescriptor()

            {
                Subject = new ClaimsIdentity(new List<Claim>()
                {

                new Claim(ClaimTypes.NameIdentifier, AppUser.GetByID(ID).Username),
             
                 }, "Custom"),

                NotBefore = DateTime.Now,
                SigningCredentials = signingCredentials,
                Issuer = "self",
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                Audience = "http://localhost:4200"
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            string signedAndEncodedToken = tokenHandler.WriteToken(plainToken);


            return signedAndEncodedToken;
        }



    }
}
