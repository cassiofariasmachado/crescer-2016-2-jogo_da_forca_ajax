using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca.Repositorio
{
    public class PalavraRepositorio : IPalavraRepositorio
    {
        public Palavra Buscar(int id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Palavra.Find(id);
            }
        }

        public IEnumerable<Palavra> BuscarPalavrasAleatorias(int qtdCaracteresMinima = 0)
        {
            using(var contexto = new ContextoDeDados())
            {
                IQueryable<Palavra> query = contexto.Palavra;
                if(qtdCaracteresMinima != 0)
                {
                    query = query.Where(_ => _.Texto.Length > qtdCaracteresMinima);
                }

                return query.OrderBy(o => Guid.NewGuid()).ToList();
            }
            
        }
    }
}
