using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForcaDominio
{
    public class Jogada
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int Pontuacao { get; set; }
    }
}
