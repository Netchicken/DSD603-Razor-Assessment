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
    public class DetailsModel : PageModel
    {
        private readonly dsd03Razor2020Assessment.Data.ApplicationDbContext _context;

        public DetailsModel(dsd03Razor2020Assessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Cast Cast { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cast = await _context.Cast
                .Include(c => c.Movie).FirstOrDefaultAsync(m => m.Id == id);

            if (Cast == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
