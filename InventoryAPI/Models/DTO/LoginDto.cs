using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }

    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public Dictionary<string, List<string>> errors { get; set; }
        public string Token { get; set; }
    }
}