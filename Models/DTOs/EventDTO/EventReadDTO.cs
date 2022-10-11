using Alumni_Network_Portal_BE.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.EventDTO
{
    public class EventReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } //Nullable
        public DateTime LastUpdated { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllowGuests { get; set; }
        public List<string>? UsersResponded { get; set; } //Many-Many
        public List<string>? Topics { get; set; } //Many-Many
        public List<string>? Groups { get; set; } //Many-Many
        public List<string>? Posts { get; set; } //One-Many
        public int? AuthorId { get; set; }
        public User? Author { get; set; } //One-Many
    }
}
