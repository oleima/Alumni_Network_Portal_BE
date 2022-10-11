using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class User
    {
        // PK
        public int Id { get; set; }
        public string KeycloakId { get; set; }
        // Fields
        [Required]
        public string Username { get; set; }
        [Required]
        public string Status { get; set; }
        public string? Bio { get; set; }
        public string? FunFact { get; set; }
        public byte[]? Picture { get; set; }

        // Relationships
        public ICollection<Post>? AuthoredPosts { get; set; } //One-Many
        public ICollection<Post>? RecievedPosts { get; set; } //One-Many
        public ICollection<Event>? AuthoredEvents { get; set; } //One-Many
        public ICollection<Topic>? Topics { get; set; } //Many-Many
        public ICollection<Group>? Groups { get; set; } //Many-Many
        public ICollection<Event>? RespondedEvents { get; set; } //Many-Many
        public ICollection<Event>? InvitedEvents { get; set; } //Many-Many
    }
}
