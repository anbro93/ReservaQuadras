using Microsoft.EntityFrameworkCore;

namespace ReservaQuadras.Models
{

    public class ReservaQuadraContext : DbContext
    {

        public ReservaQuadraContext(DbContextOptions<ReservaQuadraContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Atletica> Atleticas { get; set; }
        public DbSet<PessoaAtletica> PessoaAtleticas { get;set; }

    }
}
