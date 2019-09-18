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
    public class DeleteModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public DeleteModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Paciente Paciente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Paciente = await _context.Pacientes.FirstOrDefaultAsync(m => m.Id == id);

            if (Paciente == null)
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

            Paciente = await _context.Pacientes.FindAsync(id);

            if (Paciente != null)
            {
                _context.Pacientes.Remove(Paciente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
