using Microsoft.EntityFrameworkCore;
using moviesASPDotNet.Models;

namespace moviesASPDotNet.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

    }
}
