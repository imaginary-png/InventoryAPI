using InventoryAPI.Models.DTO;
using System.Threading.Tasks;

namespace InventoryAPI.Models.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<AuthResponseDto> Login(LoginDto userLogin);
    }
}