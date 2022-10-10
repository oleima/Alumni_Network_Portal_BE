﻿using Alumni_Network_Portal_BE.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Models.DTOs.PostDTO
{
    public class PostCreateDTO
    {
        public string Title { get; set; }
        public string? Body { get; set; }
        public int? AuthorId { get; set; }
        public int? RecieverId { get; set; }
        public int? TopicId { get; set; }
        public int? GroupId { get; set; }
        public int? EventId { get; set; }
        public int? ParentId { get; set; }
    }
}
