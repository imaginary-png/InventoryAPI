using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryAPI.Models.Repository.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryItem>> Get();
    }
}