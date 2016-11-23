using System.Collections.Generic;

namespace JogoDaForca.Dominio.Repositorios
{
    public interface ILeaderboardRepositorio
    {
        Leaderboard Buscar(int id);
        void Inserir(Leaderboard leaderboard);
        IList<Leaderboard> Listar(int pagina, int tamanhoPagina);
        IList<Leaderboard> Listar(int pagina, int tamanhoPagina, Dificuldade dificuldade);
        int ContarRegistros();
    }
}