using System.Threading.Tasks;
using InventoryAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Models.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<AuthResponseDto> Login(LoginDto userLogin);
        void Add(InventoryItem item);
        void Delete(InventoryItem item);
        void ChangeQuantity(ChangeQuantityDto changeQuantity);
    }
}