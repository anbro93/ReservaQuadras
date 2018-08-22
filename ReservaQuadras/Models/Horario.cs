using ReservaQuadras.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaQuadras.Models
{
    public class Horario
    {

        public int HorarioID { get; set; }

        [Display(Name = "Dia da Semana")]
        public int DiaID { get; set; }
        public virtual DiaDaSemana Dia { get; set; }

        public int EspacoFisicoID { get; set; }
        public virtual EspacoFisico EspacoFisico { get; set; }

        [Required]
        [Display(Name = "Hora de Inicio")]
        [TimeRangeValidation]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        [Display(Name = "Hora de Fim")]
        public TimeSpan HoraFim { get; set; }

    }
}
