using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BebraMusic.UI.Pages.Authors
{
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
            var existingAuthor = _dbContext.Authors.FirstOrDefault(a => a.Id == Author.Id);
            if (existingAuthor != null)
            {
                TempData["ErrorMessage"] = "Такой Id уже занят.";
            }
            else
            {
                _dbContext.Add(Author);
                _dbContext.SaveChanges();

                Author = new Author();

                return RedirectToPage("Index");
            }

            return Page();
        }
        
    }
}