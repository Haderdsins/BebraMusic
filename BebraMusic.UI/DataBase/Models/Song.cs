namespace BebraMusic.UI.DataBase.Models;

public class Song
{
    public int Id { get; set; } // Идентификатор песни
    public string? Title { get; set; } // Название песни, поле может быть hull так как ?
    public Author? Artist { get; set; }  // Автор песни
    public Album? Album { get; set; } // Альбом, к которому принадлежит песня
    public Genre? Genre { get; set; }
    public TimeSpan? Duration { get; set; } // Продолжительность песни
}