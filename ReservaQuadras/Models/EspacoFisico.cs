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
        public Boolean IsLiberado { get; set; }

    }
}
