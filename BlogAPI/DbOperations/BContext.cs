using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;

namespace BlogAPI.DbOperations
{
	public class BContext : DbContext
	{

        public BContext(DbContextOptions<BContext> options) : base(options) { }
		public DbSet<Blog>? Blogs { get; set; }
		public DbSet<Comment>? Comments { get; set; }
		public DbSet<Writer>? Writers { get; set; }
	}
}