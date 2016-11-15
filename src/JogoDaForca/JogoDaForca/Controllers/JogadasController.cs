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
using JogoDaForca.Dominio;
using JogoDaForca.Repositorio;
using JogoDaForca.Dominio.Interfaces;
using JogoDaForca.Servicos;

namespace JogoDaForca.Controllers
{
    public class JogadasController : ApiController
    {
        private IJogadaRepositorio jogadas = ServicoDeDependencias.MontarJogadaRepositorio();

        // GET: api/jogadas
        [ResponseType(typeof(Jogada))]
        public IHttpActionResult GetJogada(int id)
        {
            Jogada jogada = jogadas.GetJogadaPorId(id);
            if (jogada == null)
            {
                return NotFound();
            }

            return Ok(jogada);
        }


        // GET: api/jogadas
        public IHttpActionResult GetJogada(int pagina = 1, int tamanhoPagina = 5)
        {
            //pagina = pagina ?? 1;
            //tamanhoPagina = tamanhoPagina ?? 5;

            // simulando lentidão
            //System.Threading.Thread.Sleep(1500);

            var registros = jogadas.RankearJogadasPorPontuacao(pagina, tamanhoPagina);

            return Ok(new
            {
                total = jogadas.ContarRegistros(),
                dados = registros
            });
        }

        // GET: api/jogadas
        public IHttpActionResult GetJogada(int pagina = 1, int tamanhoPagina = 5, string modo)
        {
            //pagina = pagina ?? 1;
            //tamanhoPagina = tamanhoPagina ?? 5;

            // simulando lentidão
            //System.Threading.Thread.Sleep(1500);

            var registros = jogadas.RankearJogadasPorDificuldade(pagina, tamanhoPagina, modo);

            return Ok(new
            {
                total = jogadas.ContarRegistros(),
                dados = registros
            });
        }


        // POST: api/jogadas
        [ResponseType(typeof(Jogada))]
        public IHttpActionResult PostJogada(Jogada jogada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            jogadas.Adicionar(jogada);

            return CreatedAtRoute("DefaultApi", new { id = jogada.Id }, jogada);
        }


    }
}