using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            // Проверяем, существует ли артист с таким id
            if (_dbContext.Authors.Any(a => a.Id == Author.Id))
            {
                TempData["ErrorMessage"] = "Артист с таким Id уже существует.";
                return RedirectToPage();
            }

            // Если проверка прошла успешно, добавляем артиста в базу данных
            _dbContext.Add(Author);
            _dbContext.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}