using BebraMusic.UI.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BebraMusic.UI.DataBase;
 
public sealed class BebraMusicDbContext : DbContext
{
    // Свойство DbSet представляет собой коллекцию объектов, которая сопоставляется с определенной таблицей в базе данных. 
    //dbset - свойство, Author - указатель на класс, authors - там будет находиться выгрузка авторов
    public DbSet<Author> Authors { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Song> Songs { get; set; }

    public BebraMusicDbContext(DbContextOptions<BebraMusicDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
}
//docker run -d -p 15432:5432 --name my_bebra_db -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres postgres:latest

