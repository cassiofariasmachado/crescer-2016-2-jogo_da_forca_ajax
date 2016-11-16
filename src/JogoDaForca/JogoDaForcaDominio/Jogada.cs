using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.Dominio
{
    public class Jogada
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int Pontuacao { get; set; }
        public string Modo { get; set; }


    }
}
