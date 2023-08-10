using Microsoft.EntityFrameworkCore;

namespace moviesASPDotNet.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }



    }
}
