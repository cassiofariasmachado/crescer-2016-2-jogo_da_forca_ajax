class TelaPrincipal {

  constructor(seletor) {
    this.$elem = $(seletor);
    this.renderizarEstadoInicial();
  }

  registrarBindsEventos(self) {

  }

  renderizarEstadoInicial() {
    this.$elem.show();
    jogoDaForca.render('#tela-principal', 'tela-principal');
  }
}