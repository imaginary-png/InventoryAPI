using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models.DTO
{
    public class UpdateItemDto
    {
        [Required] public string SKU { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
