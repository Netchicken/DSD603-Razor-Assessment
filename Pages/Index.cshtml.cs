#nullable disable
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

using dsd03Razor2020Assessment.Data;

using Microsoft.AspNetCore.Mvc.RazorPages;
namespace dsd03Razor2020Assessment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets or sets the collection of movies resulting from a query or operation.
        /// </summary>
        public IEnumerable<Movie> Results { get; set; }


        public async Task OnGetAsync()
        {
            //get the movie title  https://github.com/nCubed/TheMovieDbWrapper https://github.com/nCubed/TheMovieDbWrapper/blob/master/DM.MovieApi.IntegrationTests/MovieDb/Movies/ApiMovieRequestTests.cs

            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;


            //  ApiQueryResponse<Movie> response = await movieApi.GetLatestAsync("en");
            // ApiSearchResponse<Movie> response = await movieApi.GetUpcomingAsync();
            ApiSearchResponse<Movie> response = await movieApi.GetNowPlayingAsync();

            //this is what is passed to the front
            Results = response.Results;

        }


    }
}


//public async Task<IActionResult> OnPostAsync()
//{
//    if (!ModelState.IsValid)
//    {
//        return Page();
//    }

//    _context.Movie.Add(Movie);
//    await _context.SaveChangesAsync();

//    return RedirectToPage("./Index");
//}