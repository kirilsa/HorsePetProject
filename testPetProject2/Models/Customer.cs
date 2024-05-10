using System.ComponentModel.DataAnnotations;

namespace testPetProject2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Message { get; set; }
    }
}
