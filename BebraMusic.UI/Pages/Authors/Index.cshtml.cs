using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Authors;

public class Index : PageModel
{
    private readonly BebraMusicDbContext _dbContext;

    public IEnumerable<Author>? Authors { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; } 
    public Index(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        Authors = _dbContext.Authors.ToList();
        if (SearchString !=null)
        {
            //язык запросов LinQ - позволяет работать с коллекциями, СContains - метод позволяет сопоставлять строску со строкой в таблице, х это объект класса
            Authors = _dbContext.Authors.Where(x => x.Name.Contains(SearchString));
        }
        else
        {
            Authors = _dbContext.Authors.ToList();
        }
        
    }
}