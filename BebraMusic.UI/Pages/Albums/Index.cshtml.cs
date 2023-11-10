using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BebraMusic.UI.Pages.Albums
{
    public class Index : PageModel
    {
        private readonly BebraMusicDbContext _dbContext;

        public IEnumerable<Album>? Albums { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } 

        public Index(BebraMusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            var query = _dbContext.Albums.Include(x=>x.Author).Include(x=>x.Genre).AsQueryable();


            if (SearchString != null)
            {
                // Язык запросов LinQ - позволяет работать с коллекциями, Contains - метод позволяет сопоставлять строку со строкой в таблице, x - это объект класса
                query = query.Where(x => x.Title.Contains(SearchString));
            }

            // Добавляем сортировку по Id
            Albums = query.OrderBy(x => x.Id).ToList();
        }
    }
}