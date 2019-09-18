using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBoxManager.Data;
using SBoxManager.Data.DTOs.ODO;

namespace SBoxManager.Pages.odo.historiales
{
    public class EditModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public EditModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacienteHistorial PacienteHistorial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PacienteHistorial = await _context.PacienteHistoriales
                .Include(p => p.Paciente).FirstOrDefaultAsync(m => m.Id == id);

            if (PacienteHistorial == null)
            {
                return NotFound();
            }
           ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PacienteHistorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteHistorialExists(PacienteHistorial.Id))
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

        private bool PacienteHistorialExists(int id)
        {
            return _context.PacienteHistoriales.Any(e => e.Id == id);
        }
    }
}
