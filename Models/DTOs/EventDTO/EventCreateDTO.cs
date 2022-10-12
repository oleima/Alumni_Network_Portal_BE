using Alumni_Network_Portal_BE.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.EventDTO
{
    public class EventCreateDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; } //Nullable
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllowGuests { get; set; }
        public List<string>? Topics { get; set; } //Many-Many
        public List<string>? Groups { get; set; } //Many-Many
    }
}
