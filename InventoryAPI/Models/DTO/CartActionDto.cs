using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models.DTO
{
    public class CartActionDto
    {
        [Required]
        public string SKU { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }
    }
}