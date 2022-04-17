using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Cart
    { //is cart needed? Could just associate CartItem with CustomerID

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Required]
        public string CartID { get; set; }

        [ForeignKey("Customer"), Required]
        public string UserID { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<CartItem> Items { get; set; }
    }


    public class CartItem
    {
        [ForeignKey("Cart"), Required, JsonIgnore]
        public string CartID { get; set; }
        [JsonIgnore] public virtual Cart Cart { get; set; }

        [ForeignKey("InventoryItem"), Required]
        public string SKU { get; set; }

        [JsonIgnore]
        public virtual InventoryItem InventoryItem { get; set; }

        public int Quantity { get; set; }
    }
}
