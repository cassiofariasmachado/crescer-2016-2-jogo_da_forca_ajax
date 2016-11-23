using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using JogoDaForca.Servicos;
using System.Web.Http;
using System.Web.Http.Description;

namespace JogoDaForca.Controllers
{
    public class LeaderboardsController : ApiController
    {
        ////TO-DO: criar serviço para isso
        //private ILeaderboardRepositorio leaderboardRepositorio = ServicoDeDependencias.MontarJogadaRepositorio();

        //// GET: api/jogadas
        //[ResponseType(typeof(Leaderboard))]
        //public IHttpActionResult GetLeaderboard(int id)
        //{
        //    Leaderboard leaderboard = leaderboardRepositorio.Buscar(id);
        //    if (leaderboard == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(leaderboard);
        //}


        //// GET: api/jogadas
        //public IHttpActionResult GetLeaderboard(int pagina = 1, int tamanhoPagina = 5)
        //{
        //    var registros = leaderboardRepositorio.Listar(pagina, tamanhoPagina);

        //    return Ok(new
        //    {
        //        total = leaderboardRepositorio.ContarRegistros(),
        //        dados = registros
        //    });
        //}

        //// GET: api/jogadas
        //public IHttpActionResult GetLeaderboard(Dificuldade dificuldade, int pagina = 1, int tamanhoPagina = 5)
        //{
        //    var registros = leaderboardRepositorio.Listar(pagina, tamanhoPagina, dificuldade);

        //    return Ok(new
        //    {
        //        total = leaderboardRepositorio.ContarRegistros(),
        //        dados = registros
        //    });
        //}


        //// POST: api/jogadas
        //[ResponseType(typeof(Leaderboard))]
        //public IHttpActionResult PostLeaderboard(Leaderboard leaderboard)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    leaderboardRepositorio.Inserir(leaderboard);

        //    return CreatedAtRoute("DefaultApi", new { id = leaderboard.Id }, leaderboard);
        //}
    }
}