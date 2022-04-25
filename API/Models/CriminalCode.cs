using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class CriminalCode
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(1024)]
        public string Description { get; set; } = null!;
        [Required]
        public float Penalty { get; set; }
        [Required]
        public int PrisonTime { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime? UpdateDate { get; set; }
        [ForeignKey("User")]
        public int CreateUserId { get; set; }
        public User CreateUser { get; set; } = null!;
        [ForeignKey("User")]
        public int? UpdateUserId { get; set; }
        public User? UpdateUser { get; set; }
    }
}