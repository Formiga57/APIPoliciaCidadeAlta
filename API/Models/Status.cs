using System.ComponentModel.DataAnnotations;
namespace API.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;
    }
}