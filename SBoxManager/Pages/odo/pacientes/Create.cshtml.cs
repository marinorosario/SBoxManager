using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBoxManager.Data;
using SBoxManager.Data.DTOs;
using SBoxManager.Data.DTOs.ODO;
using SBoxManager.Utilities;

namespace SBoxManager.Pages.odo.pacientes
{
    public class CreateModel : PageModel
    {
        private readonly SBoxManager.Data.ApplicationDbContext _context;

        public CreateModel(SBoxManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Paciente Paciente { get; set; }

        [BindProperty]
        public Persona Persona { get; set; }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var filePath = "<PATH-AND-FILE-NAME>";
            //var filePath = "wwwroot/fotos";

            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    FileUpload file = new FileUpload();
            //    await file.Foto.CopyToAsync(fileStream);
            //}

            //await FileHelpers.ProcessFormFile(FileUpload.Foto, ModelState);

            using (var trans = _context.Database.BeginTransactionAsync()) {
                try
                {
                    Persona.Codigo = Guid.NewGuid();
                    Persona.Creado = DateTime.UtcNow;
                    Persona.CreadoPor = User.Identity.Name;

                    _context.Personas.Add(Persona);
                    await _context.SaveChangesAsync();

                    Paciente.Persona = Persona;
                    //Paciente.Foto = FileUpload.Foto.FileName;
                    
                    Paciente.Edad = CalcAge(Paciente.Persona.DoB);
                    Paciente.Creado = Persona.Creado;
                    _context.Pacientes.Add(Paciente);
                    await _context.SaveChangesAsync();

                    trans.Result.Commit();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
                

            }

               
            
           

            return RedirectToPage("./Index");
        }

        private int CalcAge(DateTime doB)
        {
            DateTime toDay = DateTime.Today;
            int age = toDay.Year - doB.Year;
            if (doB.Date > toDay.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}