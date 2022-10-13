using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.EventDTO;
using Alumni_Network_Portal_BE.Models.DTOs.GroupDTO;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using Alumni_Network_Portal_BE.Models.DTOs.TopicDTO;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.UserDTO
{
    public class UserReadDTO
    {
        //Fields
        public int Id { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string? Bio { get; set; } //Nullable
        public string? FunFact { get; set; } //Nullable
        public string? Picture { get; set; }
        public ICollection<PostUserReadDTO>? AuthoredPosts { get; set; } //One-Many
        public ICollection<PostGroupReadDTO>? RecievedPosts { get; set; } //One-Many
        public ICollection<EventUserReadDTO>? AuthoredEvents { get; set; } //One-Many
        public ICollection<TopicUserReadDTO>? Topics { get; set; } //Many-Many
        public ICollection<GroupUserReadDTO>? Groups { get; set; } //Many-Many
        public ICollection<EventGroupReadDTO>? RespondedEvents { get; set; } //Many-Many
        public ICollection<EventGroupReadDTO>? InvitedEvents { get; set; } //Many-Many
    }
}
