using JogoDaForca.Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JogoDaForca.Repositorio
{
    public class ContextoDeDados : DbContext
    {
        public ContextoDeDados() : base("JogoDaForca") { }

        public DbSet<Palavra> Palavra { get; set; }
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Leaderboard> Leaderboard { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
