using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Title { get; set; }
		public string? Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }
		public int? BlogId { get; set; }
        public Blog? Blog { get; set; }
		public int? Rate { get; set; }
	}
}
