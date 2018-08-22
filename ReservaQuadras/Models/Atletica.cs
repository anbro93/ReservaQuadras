using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservaQuadras.Models
{
    public class Atletica
    {

        public int AtleticaID { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<PessoaAtletica> PessoaAtletica { get; set; }

    }
}