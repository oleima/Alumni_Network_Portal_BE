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
        public string? Picture { get; set; }
        public List<string>? AuthoredPosts { get; set; } //One-Many
        public List<string>? RecievedPosts { get; set; } //One-Many
        public List<string>? AuthoredEvents { get; set; } //One-Many
        public List<string>? Topics { get; set; } //Many-Many
        public List<string>? Groups { get; set; } //Many-Many
        public List<string>? RespondedEvents { get; set; } //Many-Many
    }
}
