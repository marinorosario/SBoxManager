using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data.DTOs
{
    public abstract class Auditar
    {
        [ScaffoldColumn(false)]
        public DateTime? Creado { get; set; }
        [ScaffoldColumn(false)]
        public string CreadoPor { get; set; } //Id del usuario que ha creado el registro

        [ScaffoldColumn(false)]
        public DateTime? Modificado { get; set; }
        [ScaffoldColumn(false)]
        public string ModificadoPor { get; set; } //Id del usuario que ha modificado el registro

        [ScaffoldColumn(false)]
        public bool IsDelete { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Eliminado { get; set; }
        [ScaffoldColumn(false)]
        public string EliminadoPor { get; set; } //Id del usuario que ha modificado el registro
    }
}
