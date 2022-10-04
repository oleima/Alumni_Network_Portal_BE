using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.UserDTO
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string Status { get; set; }
        public string? Bio { get; set; }
        public string? FunFact { get; set; }
        public byte[]? Picture { get; set; }
    }
}
