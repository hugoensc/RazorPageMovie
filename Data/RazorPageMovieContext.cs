using Microsoft.EntityFrameworkCore;

namespace RazorPageMovie.Data
{
    public class RazorPageMovieContext : DbContext
    {
        public RazorPageMovieContext(DbContextOptions<RazorPageMovieContext> options) : base(options)
        {
        }

        public DbSet<RazorPageMovie.Models.Movie> Movie { get; set; }
    }
}