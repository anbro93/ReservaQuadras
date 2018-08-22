using Microsoft.EntityFrameworkCore;
using ReservaQuadras.Models;

namespace ReservaQuadras.Models
{

    public class ReservaQuadraContext : DbContext
    {

        public ReservaQuadraContext(DbContextOptions<ReservaQuadraContext> options) : base(options) {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DiaDaSemana>().HasData(new DiaDaSemana { DiaDaSemanaID = 1, Dia= "Segunda-Feira" });
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Atletica> Atleticas { get; set; }
        public DbSet<PessoaAtletica> PessoaAtleticas { get;set; }
        public DbSet<ReservaQuadras.Models.Projeto> Projeto { get; set; }
        public DbSet<ReservaQuadras.Models.PessoaProjeto> PessoaProjeto { get; set; }
        public DbSet<DiaDaSemana> DiaDaSemana{ get; set; }

    }
}
