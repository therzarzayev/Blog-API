﻿using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }
        public int? CategoryId { get; set; }
        public int? WriterId { get; set; }
        public Writer? Writer { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
