using JogoDaForca.Dominio.Repositorios;
using JogoDaForca.Repositorio;
using JogoDaForcaDominio.Servicos;

namespace JogoDaForca.Servicos
{
    public class ServicoDeDependencias
    {

        public static ServicoDeJogador MontarServicoDeJogador()
        {
            return new ServicoDeJogador(new JogadorRepositorio());
        }

        public static ServicoDePalavra MontarServicoDePalavra()
        {
            return new ServicoDePalavra(new PalavraRepositorio());
        }
    }
}