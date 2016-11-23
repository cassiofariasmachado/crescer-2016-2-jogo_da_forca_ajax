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

        public IList<Leaderboard> Listar(int pagina, int tamanhoPagina)
        {
            using (var contexto = new ContextoDeDados())
            {
                return contexto.Leaderboard.OrderBy(_ => _.Pontuacao)
                               .Skip(tamanhoPagina * (pagina - 1))
                               .Take(tamanhoPagina)
                               .ToList();
            }
        }

        public IList<Leaderboard> Listar(int pagina, int tamanhoPagina, Dificuldade dificuldade)
        {
            using (var contexto = new ContextoDeDados())
            {
                return contexto.Leaderboard.OrderBy(_ => _.Pontuacao)
                               .Where(_ => _.Dificuldade == dificuldade)
                               .Skip(tamanhoPagina * (pagina - 1))
                               .Take(tamanhoPagina)
                               .ToList();
            }
        }

        public int ContarRegistros()
        {
            using (var contexto = new ContextoDeDados())
            {
                return contexto.Leaderboard.Count();
            }
        }

    }
}