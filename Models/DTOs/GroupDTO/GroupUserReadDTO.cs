namespace Alumni_Network_Portal_BE.Models.DTOs.GroupDTO
{
    public class GroupUserReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public bool IsPrivate { get; set; }
    }
}
