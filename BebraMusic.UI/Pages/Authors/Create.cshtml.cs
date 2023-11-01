using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Authors;

public class Create : PageModel
{
    private readonly BebraMusicDbContext _dbContext;
    [BindProperty]
    public Author Author { get; set; } = new Author();

    public Create(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult OnPost()
    {
        _dbContext.Add(Author);
        _dbContext.SaveChanges();
        return RedirectToPage("Index");
    }
    
    
}
