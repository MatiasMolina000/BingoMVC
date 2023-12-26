using System.ComponentModel.DataAnnotations;

namespace APIBingo.Models.Request
{
    public class UserRequest
    {
        [Required]
        [MinLength(1, ErrorMessage = "User field is required.")]
        [MaxLength(25, ErrorMessage = "Invalid lenght for User field.")]
        public string User { get; set; } = "";
        [Required]
        [MinLength(1, ErrorMessage = "Email field is required.")]
        [MaxLength(50, ErrorMessage = "Invalid lenght for Email field.")]
        public string Email { get; set; } = "";
        [Required]
        [MinLength(1, ErrorMessage = "Password field is required.")]
        public string Password { get; set; } = "";
    }
}
