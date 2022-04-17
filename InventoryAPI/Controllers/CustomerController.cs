using InventoryAPI.Models.DTO;
using InventoryAPI.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// Login Endpoint
        /// </summary>
        /// <remarks>Test comment</remarks>
        /// <returns code="200"></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userLogin)
        {
            var result = await _repo.Login(userLogin);
            return Ok(result);
        }

        #region Cart Actions, could/should be put into own CartController

        [HttpGet("/api/[controller]/Cart")]
        [Authorize]
        public async Task<IActionResult> GetCart()
        {
            var userId = GetUserId();

            return Ok(await _repo.GetCart(userId));
        }

        /// <summary>
        /// Adds item to cart
        /// </summary>
        /// <remarks>Adds an item to the cart. If already in cart, increases quantity </remarks>
        /// <param name="cartDto">..</param>
        /// <returns></returns>
        [HttpPost("/api/[controller]/Cart")]
        [Authorize]
        public async Task<IActionResult> AddtoCart(CartActionDto cartDto)
        {
            var userId = GetUserId();

            if (await _repo.AddToCart(cartDto, userId))
            {
                return Ok(cartDto);
            }

            return NotFound(cartDto);
        }

        /// <summary>
        /// Removes items from cart.
        /// </summary>
        /// <remarks> Reduces quantity of an item in cart. if quantity reaches 0, the item is removed from the cart.</remarks>
        /// <param name="cartDto"></param>
        /// <returns></returns>
        [HttpPut("/api/[controller]/Cart")]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(CartActionDto cartDto)
        {
            var userId = GetUserId();

            if (await _repo.RemoveFromCart(cartDto, userId))
            {
                return Ok();
            }

            return NotFound();
        }

        #endregion

        #region Helper methods

        private string GetUserId()
        {
            //var userId = User.Identity.Name // this works, but apparently ClaimTypes.NameIdentifier should be used for storing User ID instead.
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        #endregion

    }
}
