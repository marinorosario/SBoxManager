using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBoxManager.Data;
using SBoxManager.Data.DTOs;
using SBoxManager.Data.DTOs.ODO;

namespace SBoxManager.Pages.odo.pacientes
{
    public class IndexModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public IndexModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Paciente> Paciente { get;set; }        

        public async Task OnGetAsync()
        {
            //Paciente = await _context.Pacientes.ToListAsync();
            Paciente = await _context.Pacientes.Include(paciente => paciente.Persona).Where(pa => pa.IsDelete.Equals(false)).ToListAsync();
            

        }
    }
}
