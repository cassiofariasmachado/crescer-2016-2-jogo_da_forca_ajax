using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca.Test.Mocks
{
    public class PalavraRepositorioMock : IPalavraRepositorio
    {
        private IList<Palavra> palavras;   

        public PalavraRepositorioMock()
        {
            this.palavras = new List<Palavra>();
            palavras.Add(new Palavra(1, "Caderno"));
            palavras.Add(new Palavra(2, "Pederneira"));
            palavras.Add(new Palavra(3, "Pedra"));
            palavras.Add(new Palavra(4, "Cadarço"));
            palavras.Add(new Palavra(5, "Abacaxi"));
            palavras.Add(new Palavra(6, "Vassoura"));
        }

        public Palavra Buscar(int id)
        {
            return this.palavras.Single(_ => _.Id == id);
        }

        public IEnumerable<Palavra> BuscarPalavrasAleatorias(int qtdCaracteresMinima = 0)
        {
            if (qtdCaracteresMinima != 0)
            {
                return this.palavras.Where(_ => _.Texto.Length > qtdCaracteresMinima)
                                    .OrderBy(o => Guid.NewGuid());
            }
            return this.palavras.OrderBy(o => Guid.NewGuid());
        }
    }
}
