using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForcaDominio.Servicos
{
    public class ServicoDeJogador
    {
        private IJogadorRepositorio repositorioJogador;

        public ServicoDeJogador(IJogadorRepositorio repositorioJogador)
        {
            this.repositorioJogador = repositorioJogador;
        }

        public Jogador AutenticarJogador(string nome)
        {
            Jogador jogador = this.repositorioJogador.Buscar(nome);

            if(jogador == null)
            {
                this.repositorioJogador.Inserir(new Jogador(nome));
                jogador = this.repositorioJogador.Buscar(nome);
            }

            return jogador;
        }
    }
}
