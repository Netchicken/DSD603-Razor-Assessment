#nullable disable
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



        public async Task OnGetAsync()
        {

        }
    }
}
