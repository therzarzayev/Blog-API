using System.ComponentModel.DataAnnotations;

namespace BlogAPImin.Models
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
    }
}
