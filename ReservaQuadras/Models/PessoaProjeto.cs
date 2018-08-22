using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaQuadras.Models
{
    public class PessoaProjeto
    {

        public int PessoaProjetoID { get; set; }

        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public int ProjetoID { get; set; }
        public virtual Projeto Projeto { get; set; }

    }
}
