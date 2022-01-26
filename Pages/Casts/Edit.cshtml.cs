#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dsd03Razor2020Assessment.Data;
using dsd03Razor2020Assessment.Models;

namespace dsd03Razor2020Assessment.Pages.Casts
{
    public class EditModel : PageModel
    {
        private readonly dsd03Razor2020Assessment.Data.ApplicationDbContext _context;

        public EditModel(dsd03Razor2020Assessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CastExists(Cast.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CastExists(Guid id)
        {
            return _context.Cast.Any(e => e.Id == id);
        }
    }
}
