using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.TopicDTO
{
    public class TopicCreateDTO
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
