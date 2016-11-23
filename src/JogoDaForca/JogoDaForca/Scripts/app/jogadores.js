class Jogadores {

  autenticar(nome) {
    return new Promise(
      (resolve) => 
        resolve($.get('api/jogadores/', { nome: nome }))
    );
  }

}