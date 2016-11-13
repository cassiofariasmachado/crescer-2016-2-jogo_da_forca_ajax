using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Interfaces;
using System;
using System.Linq;


namespace JogoDaForca.Repositorio
{
    public class PalavraRepositorio : IPalavraRepositorio
    {
        public Palavra GetPalavraPorId(int id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Palavra.FirstOrDefault(p => p.Id==id);
            }
        }

        public Palavra GetPalavraAleatoria()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Palavra.OrderBy(o => Guid.NewGuid()).First();
            }
        }
    }
}
