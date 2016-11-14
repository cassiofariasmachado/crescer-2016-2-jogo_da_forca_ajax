using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Interfaces;
using System.Linq;

namespace JogoDaForca.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario BuscarPorId(int id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Usuario.Find(id);
            }
        }

        public Usuario BuscarPorNome(string nome)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Usuario.FirstOrDefault(u => u.Nome.Equals(nome));
            }
        }

        public void Adicionar(Usuario usuario)
        {
            using (var context = new ContextoDeDados())
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
            }
        }
    }
}
