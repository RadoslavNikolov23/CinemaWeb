namespace CinemaApp.Web.Controllers
{
    using CinemaApp.Data;
    using CinemaApp.Web.ViewModels.Movie;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class MovieController : Controller
    {
        private readonly CinemaAppDbContext dbContext;

        public MovieController(CinemaAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<AllMoviesIndexViewModel> movies = await this.dbContext
                .Movies
                .Select(m => new AllMoviesIndexViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    Director = m.Director,
                    ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();

            return View(movies);
        }
    }
}
