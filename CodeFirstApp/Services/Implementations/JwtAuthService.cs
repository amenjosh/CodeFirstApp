using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CodeFirstApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CodeFirstApp.ViewModel;
using CodeFirstApp.Services.Interface;
using CodeFirstApp.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CodeFirstApp.Services.Implementation
{
    public class JwtAuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly string _secret;
        private readonly string _expDate;

        public JwtAuthService(IUserService userService, IConfiguration config)
        {
            _userService = userService;

            _secret = config["Jwt:Key"];
            _expDate = config["Jwt:ExpiryInMinutes"];
        }

        public async Task<IEnumerable<User>> AuthenticateAsync(string userName, string password)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(password);
            byte[] hash = HashAlgorithm.Create("MD5").ComputeHash(buffer);
            string encryptedPassword = Convert.ToBase64String(hash);
            var authUser = await _userService.FindByAsync(userName, encryptedPassword);

            return authUser;
        }

        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Fullname)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}