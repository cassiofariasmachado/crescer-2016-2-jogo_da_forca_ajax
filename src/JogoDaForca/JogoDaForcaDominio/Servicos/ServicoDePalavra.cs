using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForcaDominio.Servicos
{
    public class ServicoDePalavra
    {
        private IPalavraRepositorio palavraRepositorio;

        public ServicoDePalavra(IPalavraRepositorio palavraRepositorio)
        {
            this.palavraRepositorio = palavraRepositorio;
        }

        public Palavra BuscarPalavraAleatoria(Dificuldade dificuldade)
        {
            Palavra palavras = null;
            switch (dificuldade)
            {
                case Dificuldade.Normal:
                    palavras = palavraRepositorio.BuscarPalavraAleatoria();
                    break;
                case Dificuldade.BH:
                    palavras = palavraRepositorio.BuscarPalavraAleatoria(12);
                    break;
                default:
                    break;
            }
            return palavras;
        }
    }
}
