using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class Topic
    {
        // PK
        public int Id { get; set; }
        // Fields
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; } //Nullable

        // Relationships
        public ICollection<Post>? Posts { get; set; } //One-Many
        public ICollection<User>? Users { get; set; } //Many-Many
        public ICollection<Event>? Events { get; set; } //Many-Many

    }
}
