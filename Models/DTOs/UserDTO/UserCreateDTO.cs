using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.UserDTO
{
    public class UserCreateDTO
    {
        [MaxLength(255)]
        [Required]
        public string Username { get; set; }
    }
}
