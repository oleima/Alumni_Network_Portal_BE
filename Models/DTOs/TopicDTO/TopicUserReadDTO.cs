using Alumni_Network_Portal_BE.Models.DTOs.EventDTO;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;

namespace Alumni_Network_Portal_BE.Models.DTOs.TopicDTO
{
    public class TopicUserReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
    }
}
