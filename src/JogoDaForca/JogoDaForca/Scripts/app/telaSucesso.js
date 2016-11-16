class TelaSucesso {

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
        this.$btnVoltarAoJogo.on('click', function () {
            jogoDaForca.renderizarTela('inicial');
        }
        );
    }

    renderizarEstadoInicial() {
        this.$elem.show();
        return jogoDaForca.render('#tela-sucesso', 'sucesso');
    }
}