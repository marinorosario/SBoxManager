using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data.DTOs
{
    public class Telefonos : Auditar
    {
        [Key]
        public int Id { get; set; }

        [EnumDataType(typeof(TipoTelefono))]
        public TipoTelefono Tipo { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Numero { get; set; }

        [DataType(DataType.MultilineText)]
        public string Detalles { get; set; }

        [ForeignKey("Persona")]
        public int PersonaId { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
