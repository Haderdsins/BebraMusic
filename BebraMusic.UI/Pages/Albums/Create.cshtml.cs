using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Albums
{
    public class Create : PageModel
    {
        private readonly BebraMusicDbContext _dbContext;

        [BindProperty]
        public Album Album { get; set; } = new Album();

        public Create(BebraMusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnPost()
        {
            var existingAlbum = _dbContext.Albums.FirstOrDefault(a => a.Id == Album.Id);

            if (existingAlbum == null)
            {
                TempData["ErrorMessage"] = "Альбом не найдет.";
            }
            else
            {
                _dbContext.Add(Album);
                _dbContext.SaveChanges();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}