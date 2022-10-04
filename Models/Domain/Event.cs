using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class Event
    {
        // PK
        public int Id { get; set; }
        // Fields
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; } //Nullable
        [Required]
        public DateTime LastUpdated { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public bool AllowGuests { get; set; }

        // Relationships
    }
}
