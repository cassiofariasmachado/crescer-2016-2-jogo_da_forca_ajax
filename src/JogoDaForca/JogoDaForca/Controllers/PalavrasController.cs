using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JogoDaForca.Repositorio;
using JogoDaForcaDominio;
using JogoDaForcaDominio.Interfaces;
using JogoDaForca.Servicos;

namespace JogoDaForca.Controllers
{
    public class PalavrasController : ApiController
    {

        private IPalavraRepositorio palavraRepositorio = ServicoDeDependencias.MontarPalavraRepositorio();

        // GET: api/Palavras
        [ResponseType(typeof(Palavra))]
        public IHttpActionResult GetPalavra()
        {
            Palavra palavra = palavraRepositorio.GetPalavraAleatoria();
            if (palavra == null)
            {
                return NotFound();
            }

            return Ok(palavra);
        }

    }
}