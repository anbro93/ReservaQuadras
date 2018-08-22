using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservaQuadras.Models
{
    public class Pessoa
    {

        public int PessoaID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [RegularExpression("\\d{11}", ErrorMessage = "CPF deve conter apenas dígitos!")]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "Vínculo")]
        public string Vinculo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        public virtual ICollection<PessoaAtletica> PessoaAtletica { get; set; }

    }
}
