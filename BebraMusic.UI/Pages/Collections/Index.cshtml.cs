using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BebraMusic.UI.Pages.Collections

{
    public class Index : PageModel
    {
        private readonly BebraMusicDbContext _dbContext;

        public IEnumerable<Collection>? Collections { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } 

        public Index(BebraMusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            var query = _dbContext.Collections.Include(x=>x.Genre).AsQueryable();


            if (SearchString != null)
            {
                // Язык запросов LinQ - позволяет работать с коллекциями, Contains - метод позволяет сопоставлять строку со строкой в таблице, x - это объект класса
                query = query.Where(x => x.Title.Contains(SearchString));
            }

            // Добавляем сортировку по Id
            Collections = query.OrderBy(x => x.Id).ToList();
        }
    }
}