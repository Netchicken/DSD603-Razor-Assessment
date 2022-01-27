#nullable disable
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dsd03Razor2020Assessment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly dsd03Razor2020Assessment.Data.ApplicationDbContext _context;

        public IndexModel(dsd03Razor2020Assessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IReadOnlyList<MovieInfo> Results { get; set; }

        public async Task OnGetAsync()
        {
            //get the movie title  https://github.com/nCubed/TheMovieDbWrapper https://github.com/nCubed/TheMovieDbWrapper/blob/master/DM.MovieApi.IntegrationTests/MovieDb/Movies/ApiMovieRequestTests.cs

            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;


            //  ApiQueryResponse<Movie> response = await movieApi.GetLatestAsync("en");
            // ApiSearchResponse<Movie> response = await movieApi.GetUpcomingAsync();
            ApiSearchResponse<MovieInfo> response = await movieApi.GetTopRatedAsync();

            Results = response.Results;

        }
    }
}
