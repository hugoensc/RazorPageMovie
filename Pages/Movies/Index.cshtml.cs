using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
// using System.ComponentModel.DataAnnotations;


namespace RazorPageMovie.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext _context;

        public IndexModel(RazorPageMovie.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public String SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public String MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres
            IQueryable<string> genreQuery = from m in _context.Movie 
                                            orderby m.Genre 
                                            select m.Genre;

            // using System.Linq;
            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();

            // Movie = await _context.Movie.ToListAsync();
        }
    }
}
