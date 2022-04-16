using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace InventoryAPI.Models
{
    public class Customer :IdentityUser
    {
       /* [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Required]
        public string CustomerID { get; set; }*/

        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public override string Email { get; set; }


        [JsonIgnore]
        public virtual Cart Cart { get; set; }
    }
}