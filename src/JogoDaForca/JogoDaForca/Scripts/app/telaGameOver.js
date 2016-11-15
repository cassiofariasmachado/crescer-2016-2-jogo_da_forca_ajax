class TelaGameOver {

    constructor(seletor) {
        this.$elem = $(seletor);
        this.registrarBindsEventos();
        this.renderizarEstadoInicial().then(() => {
            this.registrarBindsEventos();
        });
    }

    registrarBindsEventos() {
        this.$btnVoltarAoJogo = $('#voltar-ao-jogo');
        this.$btnIrAoLeaderboard = $('#ir-ao-leaderboard');
    }

    renderizarEstadoInicial() {
        this.$elem.show();
        return jogoDaForca.render('#tela-game-over', 'game-over');
    }
}