using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaQuadras.Models.ViewModels
{
    public class ReservaViewModel
    {
        public int ReservaID { get; set; }

        public string Descricao { get; set; }

        public int TipoID { get; set; }
        public TipoReserva Tipo { get; set; }

        public ICollection<Horario> Horarios { get; set; }

        public DateTime Data { get; set; }

        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}
