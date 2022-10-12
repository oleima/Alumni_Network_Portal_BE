using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.GroupDTO
{
    public class GroupReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public bool IsPrivate { get; set; }
        public ICollection<PostReadDTO>? Posts { get; set; } //One-Many
        public List<int>? Users { get; set; }  //Many-Many
        public List<int>? Events { get; set; }//Many-Many
    }
}