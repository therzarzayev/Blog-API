using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
