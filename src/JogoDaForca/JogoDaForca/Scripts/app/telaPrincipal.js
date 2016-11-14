class TelaPrincipal {

  constructor(seletor) {
    this.$elem = $(seletor);
    let self = this;
    this.renderizarEstadoInicial()
      .then(() => {
        self.registrarBindsEventos();
        self.iniciarJogo('normal')
      })
  }

  registrarBindsEventos() {
    this.$palavra = $('#palavra');
    this.$tentativas = $('#tentativas');
    this.$tentativasErradas = $('#tentativas-erradas');
    this.$letra = $('#letra');
  }

  renderizarEstadoInicial() {
    this.$elem.show();
    return jogoDaForca.render('#tela-principal', 'tela-principal');
  }

  iniciarJogo(modo) {
    let palavras = new Palavras();
    palavras.pegarPalavraAleatoria(modo).then(
      res => {
        let palavra = res.vocabulo.toLocaleUpperCase();
        let palavraCriptografada = jogoDaForca.gerarPalavraCriptografada(palavra.length);
		let pontuacao = 0;
        let tentativas = 0;
        let tentativasErradas = 0;

		let thiz = this;

        this.atualizarPalavra(palavraCriptografada);
        this.atualizarTentativas(tentativas);

        this.$letra.keydown(function (event) {
          if (jogoDaForca.ehLetra(event.keyCode)) {
            let letra = event.key.toLocaleUpperCase();

            if (modo === 'normal') {
				if (tentativasErradas > 5) {
				return 'Game over';
				}
				if (palavra.contains(letra)) {
				  palavraCriptografada = jogoDaForca.substituirLetra(palavra, palavraCriptografada, letra);
				  thiz.atualizarPalavra(palavraCriptografada);
				}
				else {
				  tentativasErradas++;
				  thiz.atualizarTentativasErradas(tentativasErradas);
				}
				tentativas++;
				thiz.atualizarTentativas(tentativas);
            } else if (modo === 'bh') {
              thiz.modoBh();
            }

            if (!palavraCriptografada.contains('-')) {
              pontuacao++;
              return 'Rodada completa'
            }

          }
        });
      }
    );
  }

  modoNormal() {

  }

  modoBh() {
    if (tentativasErradas > 2) {
      return 'Game over';
    }
    if (palavra.contains(letra)) {
      palavraCriptografada = substituirLetra(palavra, palavraCriptografada, letra);
      this.atualizarPalavra(palavraCriptografada);
    }
    else {
      tentativasErradas++;
      this.atualizarTentativasErradas(tentativasErradas);
    }
    tentativas++;
    this.atualizarTentativas(tentativas);
  }




  atualizarPalavra(novaPalavra) {
    this.$palavra.text(novaPalavra)
  }

  atualizarTentativas(tentativas) {
    this.$tentativas.text(tentativas)
  }

  atualizarTentativasErradas(tentativasErradas) {
    this.$tentativasErradas.text(tentativasErradas)
  }

}