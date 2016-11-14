class Palavras {

  pegarPalavraAleatoria() {
    return new Promise(
      (resolve, reject) => resolve($.get('api/palavras'))
    );
  }

}