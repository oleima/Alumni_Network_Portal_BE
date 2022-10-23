using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.EventDTO;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;

namespace Alumni_Network_Portal_BE.Models.DTOs.TopicDTO
{
    public class TopicReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public ICollection<PostGroupReadDTO>? Posts { get; set; } //One-Many
        public ICollection<UserPostReadDTO>? Users { get; set; } //Many-Many
        public ICollection<EventGroupReadDTO>? Events { get; set; } //Many-Many
    }
}
