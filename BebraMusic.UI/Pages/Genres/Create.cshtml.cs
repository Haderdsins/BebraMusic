using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Genres

{
    public class Create : PageModel
    {
        private readonly BebraMusicDbContext _dbContext;
        
        [BindProperty]
        public Genre Genre { get; set; } = new Genre();

        public Create(BebraMusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnPost()
        {
            {
                _dbContext.Add(Genre);
                _dbContext.SaveChanges();

                Genre = new Genre();

                return RedirectToPage("Index");
            }

            return Page();
        }
        
    }
}