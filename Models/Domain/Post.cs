using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.Domain
{
    public class Post
    {
        // PK
        public int Id { get; set; }
        // Fields
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }

        [MaxLength(255)]
        public string? Body { get; set; } //Nullable

        // Relationships
        public int? AuthorId { get; set; }
        public User? Author { get; set; }
        public int? RecieverId { get; set; }
        public User? Reciever { get; set; }
        public int? TopicId { get; set; }
        public Topic? Topic { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public int? EventId { get; set; }
        public Event? Event { get; set; }
        public int? ParentId { get; set; }
        public Post? Parent { get; set; }


    }

}
