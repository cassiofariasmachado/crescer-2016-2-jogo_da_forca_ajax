class TelaJogo {

    constructor(seletor) {
        this.$elem = $(seletor);
        this.renderizarEstadoInicial().then(resposta => {
            this.registrarBindsEventos();
            this.novaRodada();
        });

    }

    registrarBindsEventos() {
        this.$body = $('body');
        this.$palavra = $('#palavra');
        this.dificuldade = localStorage.getItem('dificuldade');
        this.palavras = new Palavras();
        this.registraEventoTeclado();
    }

    renderizarEstadoInicial() {
        this.$elem.show();
        return jogoDaForca.render('#tela-jogo', 'tela-jogo');
    }

    novaRodada() {
        this.palavras.buscarPalavraAleatoria(this.dificuldade).then(resposta => {
            this.palavra = resposta;
            this.palavraCriptografada = jogoDaForca.gerarPalavraCriptografada(this.palavra.texto);
            this.pontuacao = 0;

            this.atualizarPalavra();
        });


    }

    registraEventoTeclado() {
        this.$body.keydown(evento => {
            if (jogoDaForca.ehLetra(evento.keyCode)) {
                let letra = evento.key;
                this.substituirLetra(letra);
                this.verificaEncerramentoDaRodada();
                this.atualizarPalavra();
            }
        });
    }


    substituirLetra(letra) {
        let palavra = this.palavra.texto;
        for (let i = 0, len = palavra.length; i < len; i++) {
            if (palavra[i] === letra) {
                this.palavraCriptografada = this.palavraCriptografada.replaceAt(i, letra);
            }
        }
    }

    atualizarPalavra() {
        this.$palavra.text(this.palavraCriptografada);
    }

    verificaEncerramentoDaRodada() {
        if (!this.palavraCriptografada.contains('-')) {
            this.pontuacao++;
            this.novaRodada();
            console.log('Encerrou a jogada!!!')
        }
    }
}