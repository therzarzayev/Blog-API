using BlogAPImin.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPImin.DbOperations{
    public class AppDb: DbContext {
    public AppDb(DbContextOptions options):base(options){}

    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Writer> Writers { get; set; } = null!;
}
}