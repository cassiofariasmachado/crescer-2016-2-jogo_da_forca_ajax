class TelaPrincipal {
  
  constructor(seletor) {
    this.$elem = $(seletor);
    this.registrarBindsEventos();
    this.renderizarEstadoInicial();
    jogoDaForca.iniciarJogo(modo);
  }

  registrarBindsEventos() {
    this.$palavra = $('#palavra');
  }

  renderizarEstadoInicial() {
    this.$elem.show();
    jogoDaForca.render('#tela-principal', 'tela-principal');
  }
}