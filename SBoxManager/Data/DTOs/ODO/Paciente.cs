using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data.DTOs.ODO
{
    public class Paciente : Auditar
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,png,jpeg,bmp,gif")]
        public string Foto { get; set; }

        public int Edad { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }

        [StringLength(128)]
        public string Ocupacion { get; set; }

        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        public virtual ICollection<PacienteHistorial> Historiales { get; set; }
    }
}
