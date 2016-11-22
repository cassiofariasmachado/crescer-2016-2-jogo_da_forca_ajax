using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.Dominio.Repositorios
{
    public interface IJogadorRepositorio
    {
        Jogador Buscar(int id);
        Jogador Buscar(string nome);
        void Inserir(Jogador jogador);
    }
}
