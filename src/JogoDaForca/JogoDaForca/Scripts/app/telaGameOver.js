class TelaGameOver {

    constructor(seletor) {
        this.$elem = $(seletor);
        this.registrarBindsEventos();
        this.renderizarEstadoInicial();
    }

    registrarBindsEventos() {
        this.$btnVoltarAoJogo = $('#voltar-ao-jogo');
        this.$btnIrAoLeaderboard = $('#ir-ao-leaderboard');

    }

    renderizarEstadoInicial() {
        this.$elem.show();
    }
}