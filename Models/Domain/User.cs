using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class User
    {
        // PK
        public int Id { get; set; }
        // Fields
        [MaxLength(255)]
        [Required]
        public string Status { get; set; }

        [MaxLength(255)]
        public string? Bio { get; set; } //Nullable
        [MaxLength(255)]
        public string? FunFact { get; set; } //Nullable

        // Relationships
    }
}
