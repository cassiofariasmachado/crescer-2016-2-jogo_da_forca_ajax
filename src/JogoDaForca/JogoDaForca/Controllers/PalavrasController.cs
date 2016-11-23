using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using JogoDaForca.Servicos;
using JogoDaForcaDominio.Servicos;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace JogoDaForca.Controllers
{
    public class PalavrasController : ApiController
    {
        private ServicoDePalavra servicoDePalavra = ServicoDeDependencias.MontarServicoDePalavra();

        // GET: api/Palavras
        [ResponseType(typeof(Palavra))]
        public IHttpActionResult GetPalavra(Dificuldade dificuldade)
        {
            Palavra palavra = servicoDePalavra.BuscarPalavraAleatoria(dificuldade);
            if(palavra == null)
            {
                return NotFound();
            }
            return Ok(palavra);
        }
    }
}