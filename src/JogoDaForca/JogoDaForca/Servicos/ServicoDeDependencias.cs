using JogoDaForca.Repositorio;
using JogoDaForca.Dominio.Interfaces;

namespace JogoDaForca.Servicos
{
    public class ServicoDeDependencias
    {

        public static IPalavraRepositorio MontarPalavraRepositorio()
        {
            return new PalavraRepositorio();
        }

        public static IUsuarioRepositorio MontarUsuarioRepositorio()
        {
            return new UsuarioRepositorio();
        }

        public static IJogadaRepositorio MontarJogadaRepositorio()
        {
            return new JogadaRepositorio();
        }
}
}