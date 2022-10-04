using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.EventDTO
{
    public class EventCreateDTO
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
