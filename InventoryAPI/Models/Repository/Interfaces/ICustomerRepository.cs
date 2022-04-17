using InventoryAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryAPI.Models.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<AuthResponseDto> Login(LoginDto userLogin);
        Task<IEnumerable<GetCartDto>> GetCart(string userId);
        Task<bool> AddToCart(CartActionDto dto, string userId);
        Task<bool> RemoveFromCart(CartActionDto dto, string userId);
    }
}