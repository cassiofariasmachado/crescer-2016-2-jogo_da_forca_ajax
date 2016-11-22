using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using JogoDaForca.Servicos;
using System.Web.Http;
using System.Web.Http.Description;

namespace JogoDaForca.Controllers
{
    public class JogadoresController : ApiController
    {
        //TO-DO: criar serviço para isso
        private IJogadorRepositorio jogadorRepositorio = ServicoDeDependencias.MontarUsuarioRepositorio();

        // GET: api/Jogadores/5
        [ResponseType(typeof(Jogador))]
        public IHttpActionResult GetJogador(string nome)
        {
            Jogador jogador = jogadorRepositorio.Buscar(nome);
            if (jogador == null)
            {
                return NotFound();
            }
            return Ok(jogador);
        }

        // POST: api/Jogadores
        [ResponseType(typeof(Jogador))]
        public IHttpActionResult PostJogador(Jogador jogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            jogadorRepositorio.Inserir(jogador);
            return CreatedAtRoute("DefaultApi", new { id = jogador.Id }, jogador);
        }
    }
}