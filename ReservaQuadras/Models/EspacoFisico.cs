using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaQuadras.Models
{
    public class EspacoFisico
    {

        public int EspacoFisicoID { get; set; }

        [Required]
        public string Nome { get; set; }

        [DefaultValue("true")]
        [Display(Name = "Liberado")]
        public Boolean IsLiberado { get; set; }

        public virtual ICollection<Horario> Horarios { get; set; }

    }
}
