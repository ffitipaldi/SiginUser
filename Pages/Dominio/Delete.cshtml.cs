#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiginUser.Data;
using SiginUser.Models;

namespace SiginUser.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly SiginUser.Data.ApplicationDbContext _context;

        public DeleteModel(SiginUser.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dominio = await _context.Dominios.FindAsync(id);

            if (Dominio != null)
            {
                _context.Dominios.Remove(Dominio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
