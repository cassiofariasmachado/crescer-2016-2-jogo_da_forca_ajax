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
      resposta => {

        this.palavra = resposta.vocabulo.toLocaleUpperCase();
        this.palavraCriptografada = jogoDaForca.gerarPalavraCriptografada(this.palavra.length);
        this.pontuacao = 0;
        this.tentativas = 0;
        this.tentativasErradas = 0;

        let self = this;

        self.atualizarPalavra(self.palavraCriptografada);
        self.atualizarTentativas(self.tentativas);

        self.$letra.keydown(function (event) {
          if (jogoDaForca.ehLetra(event.keyCode)) {
            self.letra = event.key.toLocaleUpperCase();

            switch(modo) {
              case 'normal':
                  self.modoNormal();
                  break;
              case 'bh':
                  self.modoBh();
                  break;
              default:
                  cosole.log('Verificar switch do modo de jogo!');
            }

            self.verificarLetra();

            if (!self.palavraCriptografada.contains('-')) {
              self.pontuacao++;
              console.log('TO-DO: Rodada completa'); 
            }

          }
        });
      }
    );
  }

  modoNormal() {
    if (this.tentativasErradas === 5) {
      console.log('TO-DO: Game over');
    }
  }

  modoBh() {
    if (this.tentativasErradas === 2) {
      console.log('TO-DO: Game over');
    }
  }

  verificarLetra() {
    if (this.palavra.contains(this.letra)) {
      this.palavraCriptografada = jogoDaForca.substituirLetra(this.palavra, this.palavraCriptografada, this.letra);
      this.atualizarPalavra(this.palavraCriptografada);
    }
    else {
        this.tentativasErradas++;
        this.atualizarTentativasErradas(this.tentativasErradas);
    }
    this.tentativas++;
    this.atualizarTentativas(this.tentativas);
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