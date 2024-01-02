using System.ComponentModel.DataAnnotations;

namespace APIBingo.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public short StatusId { get; set; }
        [Required]
        public string User { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string PassTemp { get; set; } = "";
        public DateTime? Created { get; set; }
    }
}
