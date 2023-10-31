namespace BebraMusic.UI.DataBase.Models;

public class Collection
{
    public int ID { get; set; } // Идентификатор сборника
    public string Title { get; set; } // Название сборника
    public List<Song> Songs { get; set; } // Список песен в сборнике
    public Genre Genre { get; set; } // Жанр сборника
}