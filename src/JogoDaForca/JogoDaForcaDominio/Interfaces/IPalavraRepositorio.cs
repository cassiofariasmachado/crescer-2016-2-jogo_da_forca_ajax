using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForcaDominio.Interfaces
{
    public interface IPalavraRepositorio
    {
        Palavra GetPalavraPorId(int id);
        Palavra GetPalavraAleatoria();
    }
}
