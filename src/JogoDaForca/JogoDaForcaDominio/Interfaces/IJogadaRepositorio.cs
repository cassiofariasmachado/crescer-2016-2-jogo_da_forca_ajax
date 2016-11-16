using JogoDaForca.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.Dominio.Interfaces
{ 
    public interface IJogadaRepositorio
    {
        Jogada GetJogadaPorId(int id);
        IEnumerable<Jogada> RankearJogadasPorPontuacao(int pagina, int tamanhoPagina);
        int ContarRegistros();
        void Adicionar(Jogada jogada);
        IEnumerable<Jogada> RankearJogadasPorDificuldade(int pagina, int tamanhoPagina,string modo);
    }
}