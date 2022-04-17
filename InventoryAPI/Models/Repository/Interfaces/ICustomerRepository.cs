using System.Threading.Tasks;
using InventoryAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Models.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<AuthResponseDto> Login(LoginDto userLogin);
    }
}