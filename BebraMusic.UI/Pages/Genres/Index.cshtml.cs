using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BebraMusic.UI.Pages.Genres
{
    public class Index : PageModel
    {
        private readonly BebraMusicDbContext _dbContext;

        public IEnumerable<Genre>? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } 

        public Index(BebraMusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            var query = _dbContext.Genres.AsQueryable();

            if (SearchString != null)
            {
                // Язык запросов LinQ - позволяет работать с коллекциями, Contains - метод позволяет сопоставлять строку со строкой в таблице, x - это объект класса
                query = query.Where(x => x.Name.Contains(SearchString));
            }

            // Добавляем сортировку по Id
            Genres = query.OrderBy(x => x.Id).ToList();
        }
    }
}