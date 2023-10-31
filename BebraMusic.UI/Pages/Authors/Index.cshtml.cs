using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Authors;

public class Index : PageModel
{
    private readonly BebraMusicDbContext _dbContext;

    public IEnumerable<Author>? Authors { get; set; }

    public Index(BebraMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        Authors = _dbContext.Authors.ToList();
    }
}