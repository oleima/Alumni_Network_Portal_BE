using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Models.DTOs.TopicDTO
{
    public class TopicReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
