namespace BebraMusic.UI.DataBase.Models;

public class Song
{
    public int Id { get; set; } // Идентификатор песни
    public string? Title { get; set; } // Название песни, поле может быть hull так как ?
    public Author Artist { get; set; } = null!; // Автор песни
    public Album Album { get; set; }  = null!;// Альбом, к которому принадлежит песня
    public Genre Genre { get; set; }  = null!;
    public TimeSpan Duration { get; set; } // Продолжительность песни
}