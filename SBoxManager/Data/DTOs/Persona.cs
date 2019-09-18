using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data.DTOs
{
    public class Persona : Auditar
    {
        [Key]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public Guid Codigo { get; set; }

        [StringLength(96)]
        public string Nombre { get; set; }

        [StringLength(128)]
        public string Apellido { get; set; }
                
        [EnumDataType(typeof(TipoSexo))]
        public TipoSexo Sexo { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }


        [ForeignKey(nameof(EntidadUsuario))]
        public string UsuarioId { get; set; }

        public string NombreCompleto() {
            return string.Format("{0} {1}",Nombre, Apellido);
        }

        public virtual EntidadUsuario Usuario { get; set; }

        public virtual IEnumerable<Telefonos> Telefonos { get; set; }
    }
}
