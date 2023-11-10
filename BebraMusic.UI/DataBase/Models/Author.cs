namespace BebraMusic.UI.DataBase.Models;

public class Author
{
    public int Id { get; set; } // Идентификатор автора
    public string? Name { get; set; }// Имя автора
    public List<Song> Songs { get; set; }  = null!;// Список песен автора
    public List<Album> Albums { get; set; }  = null!;// Список альбомов автора
    
    // Другие свойства и методы класса могут быть добавлены здесь
}