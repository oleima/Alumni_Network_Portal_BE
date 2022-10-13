using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;

namespace Alumni_Network_Portal_BE.Models.DTOs.EventDTO
{
    public class EventGroupReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } //Nullable
        public DateTime LastUpdated { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllowGuests { get; set; }
        public List<int>? UsersResponded { get; set; } //Many-Many
        public UserPostReadDTO? Author { get; set; }
    }
}
