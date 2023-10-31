namespace BebraMusic.UI.DataBase.Models;

public class Genre
{
    public int Id { get; set; } // Идентификатор жанра
    public string? Name { get; set; } // Название жанра
    public List<Album> Albums { get; set; }  = null!;// Список альбомов данного жанра
    public List<Collection> Collections { get; set; }  = null!;// Список сборников данного жанра
}