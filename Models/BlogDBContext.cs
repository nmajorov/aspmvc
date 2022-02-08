using Microsoft.EntityFrameworkCore;
namespace aspmvc.Models;

public class BlogDBContext: DbContext
{
    public DbSet<Post> Posts { get; set; }
}