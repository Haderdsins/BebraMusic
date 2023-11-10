using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Albums;

public class Index : PageModel
{
    private readonly BebraMusicDbContext _dbContext;
    
    public IEnumerable<Album>? Albums { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; } 
    public Index(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        Albums = _dbContext.Albums.ToList();
        if (SearchString !=null)
        {
            //язык запросов LinQ - позволяет работать с коллекциями, СContains - метод позволяет сопоставлять строску со строкой в таблице, х это объект класса
            Albums = _dbContext.Albums.Where(x => x.Title.Contains(SearchString));
        }
        else
        {
            Albums = _dbContext.Albums.ToList();
        }
        
    }
}