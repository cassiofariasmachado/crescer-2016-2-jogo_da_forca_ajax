class Palavras {

  pegarPalavraAleatoria(dificuldade) {
      return new Promise(
          (resolve, reject) => resolve($.get('api/palavras', { dificuldade: dificuldade }))
      );
  }
}