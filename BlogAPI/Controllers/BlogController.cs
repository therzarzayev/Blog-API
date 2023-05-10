using BlogAPI.Models;
using BlogAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiController]
[Route("api")]
public class BlogController : ControllerBase
{
    private readonly IRepository<Blog> blogCollection;
    private readonly IRepository<Comment> commentCollection;
    private readonly IRepository<Writer> writerCollection;
    public BlogController(IRepository<Blog> _blogCollection, IRepository<Comment> _commentCollection, IRepository<Writer> _writerCollection)
    {
        blogCollection = _blogCollection;
        commentCollection = _commentCollection;
        writerCollection = _writerCollection;
    }

    [HttpGet("blogs")]
    public async Task<IActionResult> GetBlogs()
    {
        var blogs = await blogCollection.GetAllAsync();
        return Ok(blogs);
    }

    [HttpGet("comments")]
    public async Task<IActionResult> GetComments()
    {
        var comments = await commentCollection.GetAllAsync();
        return Ok(comments);
    }

    [HttpGet("writers")]
    public async Task<IActionResult> GetWriters()
    {
        var writers = await writerCollection.GetAllAsync();
        return Ok(writers);
    }
    /////byID
    [HttpGet("blog/{id}")]
    public async Task<IActionResult> GetBlogById(int id)
    {
        var blog = await blogCollection.GetByIdAsync(id);
        if (blog != null)
        {
            return Ok(blog);
        }
        return Content("Error 404");
    }

    [HttpGet("comment/{id}")]
    public async Task<IActionResult> GetCommentById(int id)
    {
        var comment = await commentCollection.GetByIdAsync(id);
        if (comment != null)
        {
            return Ok(comment);
        }
        return Content("Error 404");
    }

    [HttpGet("writer/{id}")]
    public async Task<IActionResult> GetWriterById(int id)
    {
        var writer = await writerCollection.GetByIdAsync(id);
        if (writer != null)
        {
            return Ok(writer);
        }
        return Content("Error 404");
    }
}
