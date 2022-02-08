using Microsoft.EntityFrameworkCore;
namespace aspmvc.Models;

public class BlogDBContext: DbContext
{
    public BlogDBContext(DbContextOptions<BlogDBContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Post> Posts { get; set; }
}