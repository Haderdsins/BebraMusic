using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Albums;

public class Index : PageModel
{
    private readonly BebraMusicDbContext _dbContext;
    
    public IEnumerable<Album>? Albums { get; set; }

    public Index(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        Albums = _dbContext.Albums.ToList();
    }
}