using JogoDaForca.Dominio.Repositorios;
using JogoDaForca.Repositorio;

namespace JogoDaForca.Servicos
{
    public class ServicoDeDependencias
    {

        public static IPalavraRepositorio MontarPalavraRepositorio()
        {
            return new PalavraRepositorio();
        }

        public static IJogadorRepositorio MontarUsuarioRepositorio()
        {
            return new JogadorRepositorio();
        }

        public static ILeaderboardRepositorio MontarJogadaRepositorio()
        {
            return new LeaderboardRepositorio();
        }
}
}