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
        public string Username { get; set; }
        [MaxLength(255)]
        [Required]
        public string Status { get; set; }
        [MaxLength(255)]
        public string? Bio { get; set; } //Nullable
        [MaxLength(255)]
        public string? FunFact { get; set; } //Nullable
        public byte[]? Picture { get; set; }

        // Relationships
        public ICollection<Post>? AuthoredPosts { get; set; } //One-Many
        public ICollection<Post>? RecievedPosts { get; set; } //One-Many
        public ICollection<Event>? AuthoredEvents { get; set; } //One-Many
        public ICollection<Topic>? Topics { get; set; } //Many-Many
        public ICollection<Group>? Groups { get; set; } //Many-Many
        public ICollection<Event>? RespondedEvents { get; set; } //Many-Many

    }
}
