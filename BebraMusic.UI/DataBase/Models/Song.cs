namespace BebraMusic.UI.DataBase.Models;

public class Song
{
    public int ID { get; set; } // Идентификатор песни
    public string Title { get; set; } // Название песни
    public Author Artist { get; set; } // Автор песни
    public Album Album { get; set; } // Альбом, к которому принадлежит песня
    public Genre Genre { get; set; } // Жанр песни
    public TimeSpan Duration { get; set; } // Продолжительность песни
}