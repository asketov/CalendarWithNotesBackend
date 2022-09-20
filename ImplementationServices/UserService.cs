using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data;
using ImplementationServices.Additionaly;
using InterfacesDomain;
using InterfacesServices;
using InterfacesServices.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ImplementationServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(ApplicationDbContext db, IConfiguration configuration)
        {
            _userRepository = new UserRepository(db);
            _configuration = configuration;
        }
        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetUserAsync(id);
        }
        public async Task<LoginResponse> Login(LoginRequest model)
        {
            var user = await _userRepository.GetUserAsync(user => user.Email == model.Email && user.Password == model.Password);
            if (user == null)
            {
                return null;
            }
            var token = _configuration.GenerateJwtToken(user);
            return new LoginResponse(user, token);
        }

        public async Task<LoginResponse> Register(RegisterUser userModel)
        {
            User user = await _userRepository.GetUserAsync(user => user.Email == userModel.Email);
            if (user == null)
            {
                await _userRepository.AddUserAsync(userModel.ToUser());
                await _userRepository.SaveAsync();
                var response = await Login(new LoginRequest
                {
                    Email = userModel.Email,
                    Password = userModel.Password
                });
                return response;
            }
            return null;
        }

        public async Task<User> CheckToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Secret"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var user = await GetById(userId);
                return user;
            }
            catch
            {
                return null;
            }
        }

    }
}
