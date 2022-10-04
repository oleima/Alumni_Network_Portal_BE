using Alumni_Network_Portal_BE.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.UserDTO
{
    public class UserReadDTO
    {
        //Fields
        public int Id { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string? Bio { get; set; } //Nullable
        public string? FunFact { get; set; } //Nullable
        public byte[]? Picture { get; set; }
        public ICollection<Post>? AuthoredPosts { get; set; } //One-Many
        public ICollection<Post>? RecievedPosts { get; set; } //One-Many
        public ICollection<Event>? AuthoredEvents { get; set; } //One-Many
        public ICollection<Topic>? Topics { get; set; } //Many-Many
        public ICollection<Group>? Groups { get; set; } //Many-Many
        public ICollection<Event>? RespondedEvents { get; set; } //Many-Many
    }
}
