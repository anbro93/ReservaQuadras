using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservaQuadras.Models
{
    public class Atletica
    {

        public Atletica()
        {
            this.Membros = new HashSet<Pessoa>();
        }

        public int AtleticaID { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Pessoa> Membros { get; set; }

    }
}