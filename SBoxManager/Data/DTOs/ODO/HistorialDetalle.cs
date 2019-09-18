using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data.DTOs.ODO
{
    public class HistorialDetalle : Auditar
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string Titulo { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Detalles { get; set; }

        [ForeignKey("PacienteHistorial")]
        public int PacienteHistorialId { get; set; }
        public virtual PacienteHistorial PacienteHistorial { get; set; }
    }
}
