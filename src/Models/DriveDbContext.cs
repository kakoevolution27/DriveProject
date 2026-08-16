using Microsoft.EntityFrameworkCore;

public class DriveDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }
    public DriveDbContext (DbContextOptions<DriveDbContext> options): base (options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}