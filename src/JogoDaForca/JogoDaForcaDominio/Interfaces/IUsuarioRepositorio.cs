using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorId(int id);
        Usuario BuscarPorNome(string nome);
        void Adicionar(Usuario usuario);
    }
}
