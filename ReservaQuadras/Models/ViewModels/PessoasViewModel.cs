using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaQuadras.Models.ViewModels
{
    public class PessoasViewModel
    {
        public PessoasViewModel()
        {
            Vinculos = new List<VinculoViewModel>()
                {
                    new VinculoViewModel(){ Nome = "Servidor", Valor = "Servidor" },
                    new VinculoViewModel(){ Nome = "Estudante", Valor = "Estudante" },
                    new VinculoViewModel(){ Nome = "Externo", Valor = "Externo" }
                };
        }
        public Pessoa Pessoa { get; set; }

        public List<VinculoViewModel> Vinculos { get; set; }

    }
}
