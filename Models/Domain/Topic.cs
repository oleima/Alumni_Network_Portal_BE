using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class Topic
    {
        // PK
        public int Id { get; set; }
        // Fields
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; } //Nullable

        // Relationships
    }
}
