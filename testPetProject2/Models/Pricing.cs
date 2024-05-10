using System.ComponentModel.DataAnnotations;

namespace testPetProject2.Models
{
    public class Pricing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NameOfService { get; set; }
        [Required]
        public int? LengthOfSession { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public string? ListOfIncluded { get; set; }
    }
}
