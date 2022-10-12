using Alumni_Network_Portal_BE.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.TopicDTO
{
    public class TopicCreateDTO 
    {
        public string Title { get; set; }
        public string? Body { get; set; }
    }
}
