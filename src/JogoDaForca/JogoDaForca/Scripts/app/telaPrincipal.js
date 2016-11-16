class TelaPrincipal {

  constructor(seletor, usuario, dificuldade) {
    this.$elem = $(seletor);
    this.usuario = usuario;
    this.dificuldade = dificuldade;
    this.renderizarEstadoInicial()
      .then(() => {
        this.registrarBindsEventos();
        this.iniciarJogo(this.dificuldade);
      })    
  }

    registrarBindsEventos() {
        this.$palavra = $('#palavra');
        this.$tentativas = $('#tentativas');
        this.$tentativasErradas = $('#tentativas-erradas');
        this.$letra = $('#letra');
        this.$palpite = $('#palpite');
        this.$btnPalpitar = $('#btn-palpitar')
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

                      switch (modo) {
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
			  
			  if(self.palavra.contains(' ')){
				self.palavraCriptografada = jogoDaForca.substituirLetra(self.palavra, self.palavraCriptografada, ' ');
				self.atualizarPalavra(self.palavraCriptografada);
			  }

              self.$btnPalpitar.on('click', function () {
                  self.$btnPalpitar.text('Palpitando...');
                  self.$btnPalpitar.attr('disabled', true);
                  self.palpitar();
              }
              );

          }
        );
    }

    modoNormal() {
        if (this.tentativasErradas === 5) {
            this.gameOver();
        }
    }

    modoBh() {
        if (this.tentativasErradas === 2) {
            this.gameOver();
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

    palpitar() {
        let palavraPalpitada = this.$palpite.val().toLocaleUpperCase();
        if (this.palavra === palavraPalpitada) {
            self.pontuacao += 2;
            this.sucesso();
            console.log('TO-DO: Rodada completa');
        }
        else {
            this.gameOver();
        }
    }

    gameOver() {
        let jogadaASerCriada = {pontuacao: self.pontuacao, usuario: usuario,modo: this.dificuldade}
        self.cadastrarNovaJogada(jogadaASerCriada);
        return jogoDaForca.renderizarTela('game-over');
            
    }

<<<<<<< Updated upstream
    cadastrarNovaJogada(jogada) {
        this.jogadas.cadastrar(jogada)
    }
=======
    sucesso() {
        return jogoDaForca.renderizarTela('sucesso');
    }

>>>>>>> Stashed changes
}