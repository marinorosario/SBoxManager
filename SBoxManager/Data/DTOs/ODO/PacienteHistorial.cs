using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data.DTOs.ODO
{
    public class PacienteHistorial : Auditar
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Motivo de la consulta")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Motivo { get; set; }
                
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Antecedentes { get; set; }

        [DisplayName("Fecha de la ultima consulta")]
        [DataType(DataType.Date)]        
        public DateTime FechaUltimaConsulta { get; set; }

        [Display(Name = "Motivo de la Ultima consulta")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string  DetalleUltimaConsulta { get; set; }
                
        [Display(Name = "Que problemas ha presentado anteriormente?")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string ProblemasAnteriores { get; set; }

        [Display(Name = "Tratamiento (Tx)")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Tratamiento { get; set; }

        #region booleanos

        [Display(Name = "Ha sido sometido quirúrgicamente")]
        [DefaultValue(false)]
        public bool Cirugia { get; set; }

        [Display(Name = "Motivo de la cirugía")]
        public string MotivoCirugia { get; set; }

        [Display(Name = "Médico que le atendió")]
        public string Medico { get; set; }

        [Display(Name = "Padece Presion Arterial")]
        public bool PresionArterial { get; set; }

        [Display(Name = "Renales - Genitales")]
        public bool RenalesGenitales { get; set; }
        public bool Gastrointestinales { get; set; }

        [Display(Name = "Hepáticos")]
        [DefaultValue(false)]
        public bool Hepaticos { get; set; }

        [DefaultValue(false)]
        public bool Pulmonales { get; set; }

        [Display(Name = "Diabetes Mellitus")]
        [DefaultValue(false)]
        public bool DiabetesMellitus { get; set; }

        [Display(Name = "Fiebre Reumática")]
        [DefaultValue(false)]
        public bool FiebreReumatica { get; set; }

        [Display(Name = "Sanguíneos")]
        [DefaultValue(false)]
        public bool Sanguineos { get; set; }

        [Display(Name = "Alérgicos")]
        [DefaultValue(false)]
        public bool Alergicos { get; set; }

        [Display(Name = "Consume algún medicamento")]
        [DefaultValue(false)]
        public bool ConsumeMedic { get; set; }

        [Display(Name = "VIH-SIDA")]
        [DefaultValue(false)]
        public bool VihSida { get; set; }

        [DefaultValue(false)]
        public bool Venereas { get; set; }

        [DefaultValue(false)]
        public bool Fuma { get; set; }

        [Display(Name = "Consume Alcohol")]
        [DefaultValue(false)]
        public bool ConsumAlcohol { get; set; }

        [DefaultValue(false)]
        public bool Penicilina { get; set; }

        [DefaultValue(false)]
        public bool Aspirina { get; set; }

        [Display(Name = "Problemas con la Anestesia")]
        [DefaultValue(false)]
        public bool ProbAnestesia { get; set; }

        [Display(Name = "Hábitos bucales")]
        [DefaultValue(false)]
        public bool Habitos { get; set; }
        
        [Display(Name = "Esta Embarazada")]
        [DefaultValue(false)]
        public bool Embarazada { get; set; }

        #endregion

        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        public virtual HistorialDetalle Detalles { get; set; }
    }
}
