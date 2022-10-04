using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.GroupDTO
{
    public class GroupCreateDTO
    {
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
    }
}
