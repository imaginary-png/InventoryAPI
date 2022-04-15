using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Data;
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
    }
}