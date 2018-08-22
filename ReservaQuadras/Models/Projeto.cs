using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservaQuadras.Models
{
    public class Projeto
    {

        public int ProjetoID { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<PessoaProjeto> PessoaProjeto { get; set; }

    }
}
