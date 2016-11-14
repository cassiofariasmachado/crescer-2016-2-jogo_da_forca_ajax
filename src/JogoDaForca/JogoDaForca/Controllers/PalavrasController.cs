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
using JogoDaForca.Servicos;
using JogoDaForca.Dominio.Interfaces;
using JogoDaForca.Dominio;

namespace JogoDaForca.Controllers
{
    public class PalavrasController : ApiController
    {

        private IPalavraRepositorio palavraRepositorio = ServicoDeDependencias.MontarPalavraRepositorio();

        // GET: api/Palavras
        [ResponseType(typeof(Palavra))]
        public IHttpActionResult GetPalavra(string dificuldade)
        {
            Palavra palavra = null;
            if ("normal".Equals(dificuldade))
            {
                palavra = palavraRepositorio.GetPalavraAleatoria();
            }
            else if ("bh".Equals(dificuldade))
            {
                palavra = palavraRepositorio.GetPalavraComMaisDe12Caractere();
            }
            
            if (palavra == null)
            {
                return NotFound();
            }

            return Ok(palavra);
        }
    }
}