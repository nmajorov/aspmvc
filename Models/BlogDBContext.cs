using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace aspmvc.Models;

public class BlogDBContext: DbContext
{
    public BlogDBContext(DbContextOptions<BlogDBContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    public Microsoft.EntityFrameworkCore.DbSet<Post> Posts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Changing Database table name to Metadata
        modelBuilder.Entity<Post>()
            .ToTable("post");
    }
}