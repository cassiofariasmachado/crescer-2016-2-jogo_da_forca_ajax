using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using JogoDaForca.Servicos;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace JogoDaForca.Controllers
{
    public class PalavrasController : ApiController
    {
        //TO-DO: criar serviço para isso
        private IPalavraRepositorio palavraRepositorio = ServicoDeDependencias.MontarPalavraRepositorio();

        // GET: api/Palavras

        [ResponseType(typeof(Palavra))]
        public IHttpActionResult GetPalavra(Dificuldade dificuldade)
        {
            IEnumerable<Palavra> palavra = null;

            //TO-DO: arrumar            
            palavra = palavraRepositorio.BuscarPalavrasAleatorias();
           
            

            return Ok(palavra);
        }
    }
}