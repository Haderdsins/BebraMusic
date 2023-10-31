namespace BebraMusic.UI.DataBase.Models;

public class Genre
{
    public int ID { get; set; } // Идентификатор жанра
    public string Name { get; set; } // Название жанра
    public List<Album> Albums { get; set; } // Список альбомов данного жанра
    public List<Collection> Collections { get; set; } // Список сборников данного жанра
}