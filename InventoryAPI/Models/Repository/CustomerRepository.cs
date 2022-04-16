using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using InventoryAPI.Data;
using InventoryAPI.JWT_Handler;
using InventoryAPI.Models.DTO;
using InventoryAPI.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Models.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private DatabaseContext _context;
        private UserManager<Customer> _userManager;
        private JwtHandler _jwtHandler;

        public CustomerRepository(DatabaseContext context, UserManager<Customer> userManager, JwtHandler jwtHandler)
        {
            _context = context;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }
        

        public async Task<AuthResponseDto> Login(LoginDto userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user == null) 
                return new AuthResponseDto
                {
                    IsAuthSuccessful = false,
                    errors = new Dictionary<string, List<string>>
                    {
                        {"Login", new List<string>{"Incorrect login details", $"Username: userLogin.Email"}}
                    }};

            if (!await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                return new AuthResponseDto
                {
                    IsAuthSuccessful = false,
                    errors = new Dictionary<string, List<string>>
                    {
                        {"Login", new List<string>{"Incorrect Password"}}
                    }
                };
            }

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            
            return new AuthResponseDto { IsAuthSuccessful = true, Token = token };
        }
    }
}