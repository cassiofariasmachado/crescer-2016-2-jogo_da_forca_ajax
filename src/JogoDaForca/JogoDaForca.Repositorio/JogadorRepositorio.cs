using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using System.Data.Entity;
using System.Linq;

namespace JogoDaForca.Repositorio
{
    public class JogadorRepositorio : IJogadorRepositorio
    {
        public Jogador Buscar(int id)
        {
            using (var contexto = new ContextoDeDados())
            {
                return contexto.Jogador.Find(id);
            }
        }

        public Jogador Buscar(string nome)
        {
            using (var contexto = new ContextoDeDados())
            {
                return contexto.Jogador.FirstOrDefault(_ => _.Nome.Equals(nome));
            }
        }

        public void Inserir(Jogador jogador)
        {
            using (var contexto = new ContextoDeDados())
            {
                contexto.Entry<Jogador>(jogador).State = EntityState.Added;
                contexto.SaveChanges();
            }
        }
    }
}
