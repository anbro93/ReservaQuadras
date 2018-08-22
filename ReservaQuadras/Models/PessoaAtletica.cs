namespace ReservaQuadras.Models
{
    public class PessoaAtletica
    {

        public int PessoaAtleticaID { get; set; }

        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }

        public int AtleticaID { get; set; }
        public Atletica Atletica { get; set; }

    }
}