using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models.DTO
{
    public class ChangeQuantityDto
    {
        [Required] public string SKU { get; set; }
        [Required] public int Quantity { get; set; }
    }
}