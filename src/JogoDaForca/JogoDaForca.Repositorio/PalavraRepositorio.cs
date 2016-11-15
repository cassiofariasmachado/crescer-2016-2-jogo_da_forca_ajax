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

        public Palavra GetPalavraComMaisDe12Caractere()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Palavra.Where(p => p.Vocabulo.Length > 12).OrderBy(o => Guid.NewGuid()).First();
            }
        }
    }
}
