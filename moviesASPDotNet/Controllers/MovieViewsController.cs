using Microsoft.AspNetCore.Mvc;
using moviesASPDotNet.Data;
using moviesASPDotNet.Models;

namespace moviesASPDotNet.Controllers
{
    [Controller]
    public class MovieViewsController : Controller
    {

        private readonly MoviesDbContext _dbContext;
        public MovieViewsController(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/movies")]
        public IActionResult MoviesPage()
        {
            List<Movie> movies = _dbContext.Movies.ToList();
            return View(movies);
        }
        [HttpGet]
        [Route("/movies/{id}")]
        public IActionResult MoviePage(int Id)
        {
            Movie movie = _dbContext.Movies.Find(Id);
            if (movie == null)
            { 
                return NotFound();
        }
            else 
                { 
                return View(movie);
                }
           
        }
    }

}
