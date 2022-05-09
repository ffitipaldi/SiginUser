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
    public class IndexModel : PageModel
    {
        private readonly SiginUser.Data.ApplicationDbContext _context;

        public IndexModel(SiginUser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dominio> Dominio { get;set; }

        public async Task OnGetAsync()
        {
            Dominio = await _context.Dominios.ToListAsync();
        }
    }
}
