class Palavras {

  pegarPalavraAleatoria(dificuldade) {
      return new Promise(
          (resolve, reject) => resolve($.get('api/palavra'+dificuldade))
          );
  }
}