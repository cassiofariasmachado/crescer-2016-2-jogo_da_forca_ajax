using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JogoDaForcaDominio.Servicos;
using JogoDaForca.Test.Mocks;
using JogoDaForca.Dominio;

namespace JogoDaForca.Test
{
    [TestClass]
    public class ServicoDeJogadorTest
    {
        private ServicoDeJogador servicoDeJogador = new ServicoDeJogador(new JogadorRepositorioMock());

        [TestMethod]
        public void AutenticarJogadorDeveRetornarUmJogador()
        {
            Jogador jogador = servicoDeJogador.AutenticarJogador("Cassio");

            Assert.AreEqual(1, jogador.Id);
            Assert.AreEqual("Cassio", jogador.Nome);
        }

        [TestMethod]
        public void AutenticarJogadorDeveCriarERetornarUmJogador()
        {
            Jogador jogador = servicoDeJogador.AutenticarJogador("Paulo");

            Assert.AreEqual(5, jogador.Id);
            Assert.AreEqual("Paulo", jogador.Nome);
        }
    }
}
