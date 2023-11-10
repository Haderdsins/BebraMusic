using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Songs;

public class Create : PageModel
{

    private readonly BebraMusicDbContext _dbContext;
    [BindProperty]
    public Song Song { get; set; } = new Song();

    public Create(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult OnPost()
    {
        if (_dbContext.Songs.Any(a => a.Id == Song.Id))
        {
            TempData["ErrorMessage"] = "Такой Id уже занят";
            return RedirectToPage();
        }

        _dbContext.Add(Song);
        _dbContext.SaveChanges();

        return RedirectToPage("Index");
    }

}