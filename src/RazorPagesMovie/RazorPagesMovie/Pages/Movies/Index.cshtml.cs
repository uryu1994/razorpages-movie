using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Domain.Entities;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Domain.Entities.MovieContext _context;

        public IndexModel(RazorPagesMovie.Domain.Entities.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public MovieCondition Condition { get; set; }

        public async Task OnGetAsync(MovieCondition condition)
        {
            var predicate = condition.CreatePredicate().Expand();
            Movie = await _context.Movie
                                  .Where(predicate)
                                  .ToListAsync();
        }
    }
}
