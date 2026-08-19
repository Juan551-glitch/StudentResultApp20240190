using Microsoft.EntityFrameworkCore;
using StudentResultApp.Models;

namespace StudentResultApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Student> StudentResults => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("StudentResults", "dbo");
            entity.HasKey(result => result.ResultID);
            entity.Property(result => result.StudentNumber).HasMaxLength(20).IsRequired();
            entity.Property(result => result.FullName).HasMaxLength(150).IsRequired();
            entity.Property(result => result.Module).HasMaxLength(100).IsRequired();
            entity.Property(result => result.Mark).HasPrecision(5, 2).IsRequired();
        });
    }
}
