#nullable disable
using dsd03Razor2020Assessment.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dsd03Razor2020Assessment.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly dsd03Razor2020Assessment.Data.ApplicationDbContext _context;

        public CreateModel(dsd03Razor2020Assessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }



        public void OnGet(string title, string releaseDate, string overview, string genre, decimal? price)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Movie = new Movie
                {
                    Title = title,
                    ReleaseDate = DateTime.TryParse(releaseDate, out var dt) ? dt : DateTime.Now,
                    Overview = overview,
                    Genre = genre,
                    Price = price ?? 0
                };
            }
        }




        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
