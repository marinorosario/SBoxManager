﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public DetailsModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
