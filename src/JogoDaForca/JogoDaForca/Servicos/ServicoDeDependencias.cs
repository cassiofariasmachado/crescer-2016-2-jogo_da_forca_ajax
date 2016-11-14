using JogoDaForca.Infraestrutura;
using JogoDaForca.Repositorio;
using JogoDaForca.Dominio.Interfaces;
using JogoDaForca.Dominio;

namespace JogoDaForca.Servicos
{
    public class ServicoDeDependencias
    {
        public static UsuarioServico MontarUsuarioServico()
        {
            UsuarioServico usuarioServico =
                new UsuarioServico(
                    new UsuarioRepositorio(),
                    new ServicoDeCriptografia());

            return usuarioServico;
        }

        public static IPalavraRepositorio MontarPalavraRepositorio()
        {
            return new PalavraRepositorio();
        }

        public static IUsuarioRepositorio MontarUsuarioRepositorio()
        {
            return new UsuarioRepositorio();
        }
    }
}