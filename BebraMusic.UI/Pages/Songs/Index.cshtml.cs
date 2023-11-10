using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BebraMusic.UI.Pages.Songs
{
    public class Index : PageModel
    {
        private readonly BebraMusicDbContext _dbContext;
        public IEnumerable<Song>? Songs { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public Index(BebraMusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void OnGet()
        {
            var query = _dbContext.Songs.Include(x=>x.Author).Include(x=>x.Genre).AsQueryable();

            if (SearchString != null)
            {
                query = query.Where(x => x.Title.Contains(SearchString));
            }

            Songs = query.OrderBy(x => x.Id).ToList();
        }
    }
}