using JogoDaForca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoDaForca.Dominio;

namespace JogoDaForca.Test.Mocks
{
    public class LeaderboardRepositorioMock : ILeaderboardRepositorio
    {
        private IList<Leaderboard> leaderboards;

        public LeaderboardRepositorioMock()
        {
            this.leaderboards = new List<Leaderboard>();
            this.leaderboards.Add(new Leaderboard(1, new Jogador(1, "Cassio"), 10, Dificuldade.BH));
            this.leaderboards.Add(new Leaderboard(2, new Jogador(2, "Joao"), 15, Dificuldade.Normal));
            this.leaderboards.Add(new Leaderboard(3, new Jogador(3, "Bibiana"), 50, Dificuldade.BH));
            this.leaderboards.Add(new Leaderboard(4, new Jogador(4, "Paula"), 5, Dificuldade.Normal));
        }

        public Leaderboard Buscar(int id)
        {
            return this.leaderboards.SingleOrDefault(_ => _.Id == id);
        }

        public int ContarRegistros()
        {
            return this.leaderboards.Count();
        }

        public void Inserir(Leaderboard leaderboard)
        {
            this.leaderboards.Add(leaderboard);
        }

        public IEnumerable<Leaderboard> Listar(int pagina, int tamanhoPagina, Dificuldade? dificuldade = default(Dificuldade?))
        {
            if (dificuldade != null)
            {
                return this.leaderboards.Where(_ => _.Dificuldade == dificuldade)
                           .OrderBy(_ => _.Pontuacao)
                           .Skip(tamanhoPagina * (pagina - 1))
                           .Take(tamanhoPagina)
                           .ToList();
            }

            return this.leaderboards.OrderBy(_ => _.Pontuacao)
                                    .Skip(tamanhoPagina * (pagina - 1))
                                    .Take(tamanhoPagina)
                                    .ToList();
        }
    }
}
