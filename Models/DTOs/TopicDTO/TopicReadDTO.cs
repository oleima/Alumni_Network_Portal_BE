using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Models.DTOs.TopicDTO
{
    public class TopicReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<string>? Posts { get; set; }
        public List<string>? Users { get; set; }
        public List<string>? Events { get; set; }
    }
}
