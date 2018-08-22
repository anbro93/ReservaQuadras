using Microsoft.EntityFrameworkCore;
using ReservaQuadras.Models;

namespace ReservaQuadras.Models
{

    public class ReservaQuadraContext : DbContext
    {

        public ReservaQuadraContext(DbContextOptions<ReservaQuadraContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaDaSemana>().HasData(
                new DiaDaSemana { DiaDaSemanaID = 1, Dia = "Segunda-Feira" },
                new DiaDaSemana { DiaDaSemanaID = 2, Dia = "Terça-Feira" },
                new DiaDaSemana { DiaDaSemanaID = 3, Dia = "Quarta-Feira" },
                new DiaDaSemana { DiaDaSemanaID = 4, Dia = "Quinta-Feira" },
                new DiaDaSemana { DiaDaSemanaID = 5, Dia = "Sexta-Feira" },
                new DiaDaSemana { DiaDaSemanaID = 6, Dia = "Sábado" },
                new DiaDaSemana { DiaDaSemanaID = 7, Dia = "Domingo" }
                );
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Atletica> Atleticas { get; set; }
        public DbSet<PessoaAtletica> PessoaAtleticas { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<PessoaProjeto> PessoaProjeto { get; set; }
        public DbSet<DiaDaSemana> DiaDaSemana { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<EspacoFisico> EspacoFisico { get; set; }

    }
}
