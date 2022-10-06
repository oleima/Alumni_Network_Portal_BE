using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.GroupDTO
{
    public class GroupCreateDTO
    {
        public string Title { get; set; }
        public string? Body { get; set; }
        public bool IsPrivate { get; set; }
    }
}
