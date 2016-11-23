using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using JogoDaForca.Servicos;
using JogoDaForcaDominio.Servicos;
using System.Web.Http;
using System.Web.Http.Description;

namespace JogoDaForca.Controllers
{
    public class JogadoresController : ApiController
    {
        private ServicoDeJogador servicoDeJogador = ServicoDeDependencias.MontarServicoDeJogador();

        // GET: api/Jogadores/5
        [ResponseType(typeof(Jogador))]
        public IHttpActionResult GetJogador(string nome)
        {
            Jogador jogador = servicoDeJogador.AutenticarJogador(nome);
            if (jogador == null)
            {
                return NotFound();
            }
            return Ok(jogador);
        }
    }
}