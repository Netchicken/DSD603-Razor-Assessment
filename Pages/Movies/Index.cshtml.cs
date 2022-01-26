#nullable disable
using dsd03Razor2020Assessment.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dsd03Razor2020Assessment.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;




        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;

        }

        public IList<Movie> Movie { get; set; }



        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();



        }
    }
}
