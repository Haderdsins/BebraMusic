using BebraMusic.UI.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BebraMusic.UI.DataBase;

public class BebraMusicDbContext
{
    
}
 
public class ApplicationContext : DbContext
{
    public DbSet<Author> Users => Set<Author>();
    public ApplicationContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=15432;Database=music_db;Username=postgres;Password=postgres");
    }
    
}