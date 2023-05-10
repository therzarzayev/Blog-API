using Microsoft.EntityFrameworkCore;
using BlogAPI.DbOperations;
using BlogAPI.Repo;
using BlogAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<BContext>(op => op.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository<Blog>, Repository<Blog>>();
builder.Services.AddScoped<IRepository<Comment>, Repository<Comment>>();
builder.Services.AddScoped<IRepository<Writer>, Repository<Writer>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
