using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.GroupDTO;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using Alumni_Network_Portal_BE.Models.DTOs.TopicDTO;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;
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
        public ICollection<UserPostReadDTO>? UserInvited { get; set; } //Many-Many
        public ICollection<UserPostReadDTO>? UsersResponded { get; set; } //Many-Many
        public ICollection<TopicUserReadDTO>? Topics { get; set; } //Many-Many
        public ICollection<GroupUserReadDTO>? Groups { get; set; } //Many-Many
        public ICollection<PostGroupReadDTO>? Posts { get; set; } //One-Many
        public int? AuthorId { get; set; }
        public User? Author { get; set; } //One-Many
    }
}
