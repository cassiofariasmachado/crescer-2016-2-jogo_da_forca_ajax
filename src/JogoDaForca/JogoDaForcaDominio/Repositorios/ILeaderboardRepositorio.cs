using System.Collections.Generic;

namespace JogoDaForca.Dominio.Repositorios
{
    public interface ILeaderboardRepositorio
    {
        Leaderboard Buscar(int id);
        void Inserir(Leaderboard leaderboard);
        IEnumerable<Leaderboard> Listar(int pagina, int tamanhoPagina, Dificuldade? dificuldade = null);
        int ContarRegistros();
    }
}