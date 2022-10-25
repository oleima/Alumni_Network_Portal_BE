using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;

namespace Alumni_Network_Portal_BE.Models.DTOs.PostDTO
{
    public class PostGroupReadDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime LastUpdated { get; set; }
        public string? Body { get; set; }
        public int? AuthorId { get; set; }
        public UserPostReadDTO? Author { get; set; }
        public int? ParentId { get; set; }

    }
}
