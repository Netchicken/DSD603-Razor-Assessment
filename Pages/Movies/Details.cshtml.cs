#nullable disable
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

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

        public Models.Movie Movie { get; set; }
        public IList<Cast> CastNames { get; set; }

        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
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


            //get the movie title  https://github.com/nCubed/TheMovieDbWrapper
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;


            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(Movie.Title);

            string posterPath = "";
            string backdropPath = "";

            if (response == null || response.Results == null || response.Results.Count == 0)
            {
                return NotFound();
            }


            foreach (MovieInfo info in response.Results)
            {
                Console.WriteLine($"{info.Title} ({info.ReleaseDate}): {info.Overview}");


                //get the first poster

                if (posterPath == "")
                {
                    posterPath = info.PosterPath;
                }

                if (backdropPath == "")
                {
                    backdropPath = info.BackdropPath;
                }

            }
            PosterPath = "https://image.tmdb.org/t/p/w200/" + posterPath;
            BackdropPath = "https://image.tmdb.org/t/p/original/" + backdropPath;


            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

//https://developers.themoviedb.org/3/getting-started/images

//{"adult":false,
//"backdrop_path":"/xRyINp9KfMLVjRiO5nCsoRDdvvF.jpg",
//"belongs_to_collection":null,
//"budget":63000000,
//"genres":[{"id":18,"name":"Drama"}],
//"homepage":"http://www.foxmovies.com/movies/fight-club",
//"id":550,
//"imdb_id":"tt0137523",
//"original_language":"en",
//"original_title":"Fight Club",
//"overview":"A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground \"fight clubs\" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.",
//"popularity":67.718,"poster_path":"/pB8BM7pdSp6B6Ih7QZ4DrQ3PmJK.jpg",
//"production_companies":[{"id":508,"logo_path":"/7PzJdsLGlR7oW4J0J5Xcd0pHGRg.png",
//"name":"Regency Enterprises",//"origin_country":"US"},{"id":711,"logo_path":"/tEiIH5QesdheJmDAqQwvtN60727.png",
//"name":"Fox 2000 Pictures",//"origin_country":"US"},{"id":20555,"logo_path":"/hD8yEGUBlHOcfHYbujp71vD8gZp.png","name":"Taurus Film","origin_country":"DE"},{"id":54051,"logo_path":null,"name":"Atman Entertainment","origin_country":""},{"id":54052,"logo_path":null,"name":"Knickerbocker Films","origin_country":"US"},{"id":4700,"logo_path":"/A32wmjrs9Psf4zw0uaixF0GXfxq.png","name":"The Linson Company","origin_country":"US"}],"production_countries":[{"iso_3166_1":"DE","name":"Germany"},{"iso_3166_1":"US","name":"United States of America"}],
//
//"release_date":"1999-10-15","revenue":100853753,"runtime":139,"spoken_languages":[{"english_name":"English","iso_639_1":"en","name":"English"}],"status":"Released","tagline":"Mischief. Mayhem. Soap.","title":"Fight Club","video":false,"vote_average":8.4,"vote_count":23352}