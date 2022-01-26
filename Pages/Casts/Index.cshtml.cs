#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dsd03Razor2020Assessment.Data;
using dsd03Razor2020Assessment.Models;

namespace dsd03Razor2020Assessment.Pages.Casts
{
    public class IndexModel : PageModel
    {
        private readonly dsd03Razor2020Assessment.Data.ApplicationDbContext _context;

        public IndexModel(dsd03Razor2020Assessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cast> Cast { get;set; }

        public async Task OnGetAsync()
        {
            Cast = await _context.Cast
                .Include(c => c.Movie).ToListAsync();
        }
    }
}
