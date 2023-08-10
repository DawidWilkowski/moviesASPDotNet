using Microsoft.AspNetCore.Mvc;
using moviesASPDotNet.Data;
using moviesASPDotNet.Models;

namespace moviesASPDotNet.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private readonly MoviesDbContext _dbContext;
        public MovieController(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns list of movies from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        /// <summary>
        /// Returns movie with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(t => t.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            { 
                return new ObjectResult(movie); 
            }
           
        }

        /// <summary>
        /// Adds new movie to database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _dbContext.Movies.Add(item);
            _dbContext.SaveChanges();
            return new OkResult();
        }

        /// <summary>
        /// Delete movie from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(long id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(t => t.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return new OkResult();
            }
        }



    }
}
