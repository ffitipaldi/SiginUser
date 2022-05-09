#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiginUser.Data;
using SiginUser.Models;

namespace SiginUser.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SiginUser.Data.ApplicationDbContext _context;

        public CreateModel(SiginUser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dominio Dominio { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dominios.Add(Dominio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
