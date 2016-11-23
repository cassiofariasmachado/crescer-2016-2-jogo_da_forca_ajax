class TelaInicial {

    constructor(seletor) {
        this.$elem = $(seletor);
        this.jogadores = new Jogadores();
        this.registrarBindsEventos();
        this.renderizarEstadoInicial();
    }

    registrarBindsEventos() {
        this.$formUsuario = $('#form-jogador');
        this.$jogador = $('#jogador');
        this.$dificuldade = $('#dificuldade');
        this.$btnJogar = $('#botao-jogar');
        
        this.$formUsuario.submit(evento => {
            this.$elem.hide();
            let nome = this.$jogador.val();
            let dificuldade = this.$dificuldade.val();
            this.jogadores.autenticar(nome)
                .then(resposta => {
                    localStorage.setObject('jogador', resposta);
                    localStorage.setItem('dificuldade', dificuldade);
                    jogoDaForca.renderizarTela('jogo');
                })
                .catch(erro => {
                    console.error(erro);
                });
            
            if (evento.preventDefault) {
                evento.preventDefault();
            }
            return false;
        });
        
    }

    renderizarEstadoInicial() {
        this.$elem.show();
    }

}