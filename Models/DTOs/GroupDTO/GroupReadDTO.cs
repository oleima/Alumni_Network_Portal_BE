using Alumni_Network_Portal_BE.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.GroupDTO
{
    public class GroupReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public bool IsPrivate { get; set; }
        public ICollection<Post>? Posts { get; set; } //One-Many
        public ICollection<User>? Users { get; set; }  //Many-Many
        public ICollection<Event>? Events { get; set; }//Many-Many
    }
}