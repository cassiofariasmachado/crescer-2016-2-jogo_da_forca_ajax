using JogoDaForcaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
