using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Models.DTOs.EventDTO
{
    public class EventUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } //Nullable
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllowGuests { get; set; }
    }
}
