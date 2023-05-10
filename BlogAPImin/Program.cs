using Microsoft.OpenApi.Models;
using BlogAPImin.DbOperations;
using Microsoft.EntityFrameworkCore;
using BlogAPImin.Models;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDb>(op=>op.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bloqum.AZ API",
        Description = "Other platforms is an open source project",
        Version = "v1"
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins(
            "http://example.com", "*");
      });
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c=>{
    c.SwaggerEndpoint("/swagger/v1/swagger.json","Bloqum.AZ API v1");
});
//////GET ALL
app.MapGet("/blogs", async (AppDb db) => await db.Blogs.ToListAsync());
app.MapGet("/comments", async (AppDb db) => await db.Comments.ToListAsync());
app.MapGet("/writers", async (AppDb db) => await db.Writers.ToListAsync());

//////GET BY ID
app.MapGet("/blog/{id}", async (AppDb db, int id) => await db.Blogs.FindAsync(id));
app.MapGet("/comment/{id}", async (AppDb db, int id) => await db.Comments.FindAsync(id));
app.MapGet("/writer/{id}", async (AppDb db, int id) => await db.Writers.FindAsync(id));

/////POST NEW ITEM
app.MapPost("/blog", async (AppDb db, Blog blog) =>
{
    await db.Blogs.AddAsync(blog);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{blog.Id}", blog);
});

app.MapPost("/comment", async (AppDb db, Comment comment) =>
{
    await db.Comments.AddAsync(comment);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{comment.Id}", comment);
});

app.MapPost("/writer", async (AppDb db, Writer writer) =>
{
    await db.Writers.AddAsync(writer);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{writer.Id}", writer);
});

//UPDATE ITEM
app.MapPut("/blog/{id}", async (AppDb db, Blog updateblog, int id) =>{
     var blog = await db.Blogs.FindAsync(id);
      if (blog is null) return Results.NotFound();
      blog.Title = updateblog.Title;
      blog.Content = updateblog.Content;
      blog.Image = updateblog.Image;
      blog.ThumbnailImage = updateblog.ThumbnailImage;
      blog.Status = updateblog.Status;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapPut("/comment/{id}", async (AppDb db, Comment updatecomment, int id) =>{
     var comment = await db.Comments.FindAsync(id);
      if (comment is null) return Results.NotFound();
      comment.UserName = updatecomment.UserName;
      comment.Title = updatecomment.Title;
      comment.Content = updatecomment.Content;
      comment.Status = updatecomment.Status;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapPut("/writer/{id}", async (AppDb db, Writer updatewriter, int id) =>{
     var writer = await db.Writers.FindAsync(id);
      if (writer is null) return Results.NotFound();
      writer.FirstName = updatewriter.FirstName;
      writer.LastName = updatewriter.LastName;
      writer.Image = updatewriter.Image;
      writer.Email = updatewriter.Email;
      writer.Password = updatewriter.Password;
      writer.Status = updatewriter.Status;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.UseCors(MyAllowSpecificOrigins);
app.Run();
//