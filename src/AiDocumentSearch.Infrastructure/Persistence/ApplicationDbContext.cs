using AiDocumentSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiDocumentSearch.Infrastructure.Persistence;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
        .HasIndex(u=>u.Email)
        .IsUnique();
    }

    public DbSet<User> Users {get; set;}
}


