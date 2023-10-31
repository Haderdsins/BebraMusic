namespace BebraMusic.UI.DataBase.Models;

public class Author
{
    public int ID { get; set; } // Идентификатор автора
    public string Name { get; set; } // Имя автора
    public List<Song> Songs { get; set; } // Список песен автора
    public List<Album> Albums { get; set; } // Список альбомов автора
    
    // Другие свойства и методы класса могут быть добавлены здесь
}