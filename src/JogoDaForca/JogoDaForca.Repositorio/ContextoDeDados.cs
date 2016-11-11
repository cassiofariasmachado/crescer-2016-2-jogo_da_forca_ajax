using JogoDaForcaDominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JogoDaForca.Repositorio
{
    public class ContextoDeDados : DbContext
    {
        public ContextoDeDados() : base("JogoDaForca")
        {

        }

        public DbSet<Palavra> Palavra { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Jogada> Jogada { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
