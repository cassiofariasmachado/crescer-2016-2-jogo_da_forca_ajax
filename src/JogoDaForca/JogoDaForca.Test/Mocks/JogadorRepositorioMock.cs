using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca.Test.Mocks
{
    public class JogadorRepositorioMock : IJogadorRepositorio
    {
        private IList<Jogador> jogadores;

        public JogadorRepositorioMock()
        {
            this.jogadores = new List<Jogador>();
            jogadores.Add(new Jogador(1, "Cassio"));
            jogadores.Add(new Jogador(2, "Joao"));
            jogadores.Add(new Jogador(3, "Bibiana"));
            jogadores.Add(new Jogador(4, "Paula"));
        }

        public Jogador Buscar(string nome)
        {
            return this.jogadores.SingleOrDefault(_ => _.Nome.Equals(nome));
        }

        public Jogador Buscar(int id)
        {
            return this.jogadores.SingleOrDefault(_ => _.Id == id);
        }

        public void Inserir(Jogador jogador)
        {
            jogador.Id = jogadores.Count + 1;
            this.jogadores.Add(jogador);
        }
    }
}
