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
    public class CreateModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public CreateModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacienteHistorial PacienteHistorial { get; set; }

        public IActionResult OnGet(int id)
        {
            PacienteHistorial = new PacienteHistorial();
            PacienteHistorial.PacienteId = id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            PacienteHistorial.Creado = DateTime.UtcNow;
            PacienteHistorial.CreadoPor = User.Identity.Name;
            PacienteHistorial.Modificado = DateTime.UtcNow;

            _context.PacienteHistoriales.Add(PacienteHistorial);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}