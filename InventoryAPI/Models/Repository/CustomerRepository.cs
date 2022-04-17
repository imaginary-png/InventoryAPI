using InventoryAPI.Data;
using InventoryAPI.JWT_Handler;
using InventoryAPI.Models.DTO;
using InventoryAPI.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

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
                        {"Login", new List<string>{"Incorrect login details", $"Username: {userLogin.Email}"}}
                    }
                };

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

        public async Task<IEnumerable<GetCartDto>> GetCart(string userId)
        {
            if (!await UserExists(userId))
            {
                return new List<GetCartDto>();
            }

            //if userId exists in db, then corresponding cartId should exist.
            var usersCartId = (await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userId)).CartID;

            //var cart = await _context.CartItems.Where(c => c.CartID == usersCartId).ToListAsync();

            var cartItems = await _context.CartItems.Where(c => c.CartID == usersCartId).ToListAsync();

            var returnCartList = new List<GetCartDto>();

            cartItems.ForEach(ci => returnCartList.Add(new GetCartDto
            {
                SKU = ci.SKU,
                Quantity = ci.Quantity
            }));


            return returnCartList;
        }

        public async Task<bool> AddToCart(CartActionDto dto, string userId)
        {
            //check is user exists
            if (!await UserExists(userId))
            {
                return false;
            }

            //get CartID for user
            //assuming cartID can't be null if userID isn't null, since they should be created together when a user registers.
            //altho=ugh registration hasn't been implemented in this test project.
            var cartId = (await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userId)).CartID;

            //check if SKU already exists in cart
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.SKU == dto.SKU && ci.CartID == cartId);

            if (cartItem == null)
            {
                if (await _context.Inventory.FirstOrDefaultAsync(i => i.SKU == dto.SKU) == null)
                {//item does not exist in inventory
                    return false;
                }
                cartItem = new CartItem() { CartID = cartId, SKU = dto.SKU, Quantity = dto.Quantity };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += dto.Quantity;
                _context.CartItems.Update(cartItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromCart(CartActionDto dto, string userId)
        {
            if (!await UserExists(userId))
            {
                return false;
            }

            var cartId = (await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userId)).CartID;

            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.SKU == dto.SKU && ci.CartID == cartId);

            if (cartItem == null)
            {
                return false;
            }

            cartItem.Quantity -= dto.Quantity;

            if (cartItem.Quantity > 0)
            {
                _context.CartItems.Update(cartItem);
            }
            else
            {
                _context.CartItems.Remove(cartItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        #region Helper methods

        private async Task<bool> UserExists(string userId)
        {
            if (await _userManager.FindByIdAsync(userId) != null)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}