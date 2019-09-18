using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBoxManager.Data;
using SBoxManager.Data.DTOs.ODO;

namespace SBoxManager.Pages.odo.pacientes
{
    public class DetailsModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public DetailsModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Paciente Paciente { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            Paciente = await _context.Pacientes.Include(p => p.Persona).FirstOrDefaultAsync(m => m.Persona.Codigo.Equals(codigo) && m.IsDelete.Equals(false));

            if (Paciente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
