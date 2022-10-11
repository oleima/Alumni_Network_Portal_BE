using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class Group
    {
        // PK
        public int Id { get; set; }
        // Fields
        [Required]
        public string Title { get; set; }
        public string? Body { get; set; } //Nullable
        [Required]
        public bool IsPrivate { get; set; }

        // Relationships
        public ICollection<Post>? Posts { get; set; } //One-Many
        public ICollection<User>? Users { get; set; }  //Many-Many
        public ICollection<Event>? Events { get; set; }//Many-Many
    }
}
