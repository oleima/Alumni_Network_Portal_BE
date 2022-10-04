using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class Group
    {
        // PK
        public int Id { get; set; }
        // Fields
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        [MaxLength(255)]
        public string? Body { get; set; } //Nullable
        [Required]
        public bool IsPrivate { get; set; } 


        // Relationships
    }
}
