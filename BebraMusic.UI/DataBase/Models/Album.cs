﻿namespace BebraMusic.UI.DataBase.Models;

public class Album
{
    public int Id { get; set; } // Идентификатор альбома
    public string? Title { get; set; } // Название альбома
    public int Year { get; set; } // Год выпуска альбома
    public List<Song> Songs { get; set; } = null!; // Список песен в альбоме
    public int ArtistId { get; set; }
    
    public Author Artist { get; set; } = null!; // Автор альбома
    public Genre Genre { get; set; } // Жанр альбома
}