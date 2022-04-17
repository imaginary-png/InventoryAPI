using System;
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

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Range(0.01, Double.MaxValue)]
        public double Price { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Stock { get; set; }
    }
}