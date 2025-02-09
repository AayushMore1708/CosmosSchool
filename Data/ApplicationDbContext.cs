// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<School> Schools { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    public DbSet<Timetable> Timetables { get; set; }
}
