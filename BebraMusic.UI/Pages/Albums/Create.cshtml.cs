using BebraMusic.UI.DataBase;
using BebraMusic.UI.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BebraMusic.UI.Pages.Albums
{
    public class Create : PageModel
    {
        [BindProperty]
        public int GenreId { get; set; }//оно
        [BindProperty]
        public int AuthorId { get; set; }//оно
        
        private readonly BebraMusicDbContext _dbContext;

        [BindProperty]
        public Album Album { get; set; } = new Album();
        
        

        public Create(BebraMusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SelectListItem>? Genres { get; private set; }
        public List<SelectListItem>? Authors { get; private set; }
        public void OnGet()
        {
            var genres = _dbContext.Genres.AsQueryable();
            Genres = genres.Select(x => new SelectListItem 
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            var authors = _dbContext.Authors.AsQueryable();
            Authors = authors.Select(x => new SelectListItem 
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        public IActionResult OnPost()
        {
            Album.GenreId = GenreId;//оно
            Album.AuthorId = AuthorId;//оно
                _dbContext.Add(Album);
                _dbContext.SaveChanges();
                return RedirectToPage("Index");
        }
    }
}