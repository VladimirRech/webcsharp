using Microsoft.EntityFrameworkCore;
namespace EFModeling.EntityProperties.FluentAPI.Required;
using study_schedule_api.Classes;

public class MyContext : DbContext
{
    public DbSet<StudyTask> StudyTask { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<StudyTask>()
            .Property(b => b.Id)
            .IsRequired();
    }
}