using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Songs;

public class Index : PageModel
{
    private readonly BebraMusicDbContext _dbContext;
    public IEnumerable<Song>? Songs { get; set;}
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set;}

    public Index(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        Songs = _dbContext.Songs.ToList();
        if (SearchString != null)
        {
            Songs = _dbContext.Songs.Where(x => x.Title.Contains(SearchString));
        }
        else
        {
                Songs = _dbContext.Songs.ToList();
        }
    }
}