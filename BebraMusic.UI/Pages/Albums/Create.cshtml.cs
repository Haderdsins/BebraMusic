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
            // Проверяем, существует ли альбом с таким id
            var existingAlbum = _dbContext.Albums.FirstOrDefault(a => a.Id == Album.Id);

            if (existingAlbum != null)
            {
                // Если альбом с таким id уже существует, выводим сообщение об ошибке
                TempData["ErrorMessage"] = "Такой Id уже занят.";
            }
            else
            {
                // Если проверка прошла успешно, добавляем альбом в базу данных
                _dbContext.Add(Album);
                _dbContext.SaveChanges();
                // Очищаем свойство Album, чтобы поля ввода на странице были пустыми
                Album = new Album();
                // Перенаправляем пользователя на страницу "Index"
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}