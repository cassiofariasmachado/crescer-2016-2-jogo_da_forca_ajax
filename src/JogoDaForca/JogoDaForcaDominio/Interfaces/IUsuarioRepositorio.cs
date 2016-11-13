using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorNome(string nome);
    }
}
