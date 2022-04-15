using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Inventory
    {
        public List<InventoryItem> InventoryList { get; set; }
    }

    public class InventoryItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Required]
        public string SKU { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}