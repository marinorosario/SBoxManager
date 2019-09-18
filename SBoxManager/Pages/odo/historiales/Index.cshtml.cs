using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBoxManager.Data;
using SBoxManager.Data.DTOs.ODO;

namespace SBoxManager.Pages.odo.historiales
{
    public class IndexModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public IndexModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PacienteHistorial> PacienteHistorial { get;set; }

        public async Task OnGetAsync()
        {
            PacienteHistorial = await _context.PacienteHistoriales
                .Include(p => p.Paciente).ToListAsync();
        }
    }
}
