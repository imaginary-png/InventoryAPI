using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Data;
using InventoryAPI.Models.DTO;
using InventoryAPI.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Models.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private DatabaseContext _context;

        public InventoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryItem>> Get()
        {
            return await _context.Inventory.ToListAsync();
        }

        public async Task<bool> Add(InventoryItem itemToAdd)
        {
            if (await ItemExists(itemToAdd.SKU) == null)
            {
                _context.Inventory.Add(itemToAdd);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(string skuToDelete)
        {
            var item = await ItemExists(skuToDelete);

            if (item != null) 
            {
                _context.Inventory.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Update(InventoryItem itemToUpdate)
        {
            var item = await ItemExists(itemToUpdate.SKU);

            if (item != null)
            {
                item.Name = itemToUpdate.Name;
                item.Description = itemToUpdate.Description;
                item.Price = itemToUpdate.Price;
                item.Stock = itemToUpdate.Stock;
                
                _context.Inventory.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }


        #region Helper methods

        private async Task<InventoryItem> ItemExists(string SKU)
        {
            var item = await _context.Inventory.FirstOrDefaultAsync(i => i.SKU == SKU);
            return item;
        }

        #endregion
    }
}