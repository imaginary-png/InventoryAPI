using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryAPI.Models.Repository.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryItem>> Get();
        Task<bool> Add(InventoryItem itemToAdd);
        Task<bool> Delete(string skuToDelete);
        Task<bool> Update(InventoryItem itemToUpdate);
    }
}