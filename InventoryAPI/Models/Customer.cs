using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace InventoryAPI.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Required]
        public string CustomerID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress] 
        public string Email { get; set; }


        [JsonIgnore]
        public virtual Cart Cart { get; set; }
    }
}