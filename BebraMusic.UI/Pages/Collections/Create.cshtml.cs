using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BebraMusic.UI.Pages.Collections;

public class Create : PageModel
{
    
    [BindProperty]
    public int GenreId { get; set; }//оно
        
    private readonly BebraMusicDbContext _dbContext;

    [BindProperty]
    public Collection Collection { get; set; } = new Collection();
        
        

    public Create(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<SelectListItem>? Genres { get; private set; }

    public void OnGet()
    {
        var genres = _dbContext.Genres.AsQueryable();
        Genres = genres.Select(x => new SelectListItem 
        {
            Value = x.Id.ToString(),
            Text = x.Name
        }).ToList();
    }
    public IActionResult OnPost()
    {
        Collection.GenreId = GenreId;//оно
        _dbContext.Add(Collection);
        _dbContext.SaveChanges();
        return RedirectToPage("Index");
    }
}