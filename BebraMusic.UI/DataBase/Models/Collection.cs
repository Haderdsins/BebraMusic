namespace BebraMusic.UI.DataBase.Models;

public class Collection
{
    public int Id { get; set; } // Идентификатор сборника
    public string? Title { get; set; } // Название сборника
    public List<Song> Songs { get; set; }  = null!;// Список песен в сборнике
    public Genre Genre { get; set; } = null!; // Жанр сборника
}