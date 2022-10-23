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
        public string Title { get; set; }

        [MaxLength(255)]
        public string? Body { get; set; } //Nullable

        // Relationships
        public ICollection<Post>? Posts { get; set; } //One-Many
        public ICollection<User>? Users { get; set; } //Many-Many
        public ICollection<Event>? Events { get; set; } //Many-Many

    }
}
