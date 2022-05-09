#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiginUser.Data;
using SiginUser.Models;

namespace SiginUser.Pages
{
    public class EditModel : PageModel
    {
        private readonly SiginUser.Data.ApplicationDbContext _context;

        public EditModel(SiginUser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dominio Dominio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dominio = await _context.Dominios.FirstOrDefaultAsync(m => m.Id == id);

            if (Dominio == null)
            {
                return NotFound();
            }
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

            _context.Attach(Dominio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DominioExists(Dominio.Id))
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

        private bool DominioExists(int id)
        {
            return _context.Dominios.Any(e => e.Id == id);
        }
    }
}
