using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Interfaces;
using System.Linq;

namespace JogoDaForca.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario BuscarPorNome(string nome)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Usuario.FirstOrDefault(u => u.Nome.Equals(nome));
            }
        }
    }
}
