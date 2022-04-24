using System.ComponentModel.DataAnnotations;
namespace API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}