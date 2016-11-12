using JogoDaForcaDominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoDaForcaDominio;

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
