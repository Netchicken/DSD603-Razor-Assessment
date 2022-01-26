#nullable disable
using dsd03Razor2020Assessment.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dsd03Razor2020Assessment.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly dsd03Razor2020Assessment.Data.ApplicationDbContext _context;

        public DetailsModel(dsd03Razor2020Assessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        public IList<Cast> CastNames { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            //get all the cast names
            CastNames = await _context.Cast.Where(c => c.MovieId == Movie.Id).ToListAsync();

            // .Select(c => new { c.FirstName, c.LastName, c.ScreenName }).Where(c => c.MovieId ==).ToListAsync();



            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
