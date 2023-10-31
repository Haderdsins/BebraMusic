namespace BebraMusic.UI.DataBase.Models;

public class Album
{
    public int ID { get; set; } // Идентификатор альбома
    public string Title { get; set; } // Название альбома
    public int Year { get; set; } // Год выпуска альбома
    public List<Song> Songs { get; set; } // Список песен в альбоме
    public Author Artist { get; set; } // Автор альбома
    public Genre Genre { get; set; } // Жанр альбома
}