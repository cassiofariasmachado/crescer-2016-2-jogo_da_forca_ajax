using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JogoDaForca.Repositorio
{
    public class LeaderboardRepositorio : ILeaderboardRepositorio
    {
        public Leaderboard Buscar(int id)
        {
            using (var contexto = new ContextoDeDados())
            {
                return contexto.Leaderboard.Find(id);
            }
        }

        public IEnumerable<Leaderboard> Listar(int pagina, int tamanhoPagina, Dificuldade? dificuldade = null)
        {
            using (var contexto = new ContextoDeDados())
            {
                IQueryable<Leaderboard> query = contexto.Leaderboard;

                if (dificuldade != null)
                {
                    query = query.Where(_ => _.Dificuldade == dificuldade);
                }

                return query.OrderBy(_ => _.Pontuacao)
                            .Skip(tamanhoPagina * (pagina - 1))
                            .Take(tamanhoPagina)
                            .ToList();
            }
        }

        public void Inserir(Leaderboard leaderboard)
        {
            using (var contexto = new ContextoDeDados())
            {
                contexto.Entry<Leaderboard>(leaderboard).State = EntityState.Added;
                if (leaderboard.Jogador != null)
                {
                    contexto.Entry<Jogador>(leaderboard.Jogador).State = EntityState.Unchanged;
                }
                contexto.SaveChanges();
            }

            
        }

        public int ContarRegistros()
        {
            using (var contexto = new ContextoDeDados())
                return contexto.Leaderboard.Count();
        }

    }
}