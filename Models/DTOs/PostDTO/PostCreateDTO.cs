using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.PostDTO
{
    public class PostCreateDTO
    {
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
    }
}
