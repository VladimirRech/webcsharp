using Microsoft.EntityFrameworkCore;
//namespace EFModeling.EntityProperties.FluentAPI.Required;
using study_schedule_api.Classes;
namespace study_schedule_api.DbContexts;

public class MyContext : DbContext
{
    public DbSet<StudyTask> StudyTask { get; set; }

    public MyContext(DbContextOptions options) : base(options)
    {

    }

    // Initial validations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudyTask>()
            .Property(b => b.Id)
            .IsRequired();

        modelBuilder.Entity<StudyTask>()
            .Property(b => b.Title)
            .IsRequired();
    }
}