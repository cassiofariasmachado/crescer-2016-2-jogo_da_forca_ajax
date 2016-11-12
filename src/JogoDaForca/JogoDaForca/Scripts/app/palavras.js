class Palavras {

  pegarPalavraAleatoria() {
    return new $.get('api/palavras');
  }

}