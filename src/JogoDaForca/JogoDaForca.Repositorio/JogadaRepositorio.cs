using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca.Repositorio
{
    public class JogadaRepositorio : IJogadaRepositorio
    {
        public Jogada GetJogadaPorId(int id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Jogada.FirstOrDefault(p => p.Id == id);
            }
        }

        public IEnumerable<Jogada> RankearJogadasPorPontuacao(int pagina, int tamanhoPagina)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Jogada
                    .OrderBy(j => j.Pontuacao)
                    .Skip(tamanhoPagina * (pagina - 1))
                    .Take(tamanhoPagina)
                    .ToList();
            }
        }
        public int ContarRegistros()
        {
            using (var contexto = new ContextoDeDados())
                return contexto.Jogada.Count();
        }

        public void Adicionar(Jogada jogada)
        {
            using (var contexto = new ContextoDeDados())
            {
                contexto.Jogada.Add(jogada);
                contexto.SaveChanges();
            }
        }
    }
}