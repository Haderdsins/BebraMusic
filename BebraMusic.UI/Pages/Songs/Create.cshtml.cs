using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BebraMusic.UI.Pages.Songs;

public class Create : PageModel
{
    [BindProperty]
    public int AlbumId { get; set; }//оно
    [BindProperty]
    public int GenreId { get; set; }//оно
    [BindProperty]
    public int AuthorId { get; set; }//оно
    
    private readonly BebraMusicDbContext _dbContext;
    [BindProperty]
    public Song Song { get; set; } = new Song();

    public Create(BebraMusicDbContext dbContext)//оно
    {
        _dbContext = dbContext;
    }
    public List<SelectListItem>? Albums { get; private set; }
    public List<SelectListItem>? Genres { get; private set; }
    public List<SelectListItem>? Authors { get; private set; }
    public void OnGet()
    {
        var albums = _dbContext.Albums.AsQueryable();
        Albums = albums.Select(x => new SelectListItem 
        {
            Value = x.Id.ToString(),
            Text = x.Title
        }).ToList();
    
        var genres = _dbContext.Genres.AsQueryable();
        Genres = genres.Select(x => new SelectListItem 
        {
            Value = x.Id.ToString(),
            Text = x.Name
        }).ToList();
        var authors = _dbContext.Authors.AsQueryable();
        Authors = authors.Select(x => new SelectListItem 
        {
            Value = x.Id.ToString(),
            Text = x.Name
        }).ToList();
    }

    public IActionResult OnPost()
    {
        if (_dbContext.Songs.Any(a => a.Id == Song.Id))
        {
            TempData["ErrorMessage"] = "Такой Id уже занят";
            return RedirectToPage();
        }
        Song.AlbumId = AlbumId;//оно
        Song.GenreId = GenreId;//оно
        Song.AuthorId = AuthorId;//оно
        
        _dbContext.Add(Song);
        _dbContext.SaveChanges();

        return RedirectToPage("Index");
    }

}