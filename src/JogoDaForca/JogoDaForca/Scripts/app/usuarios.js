class Usuarios {

  buscarUsuario(nome) {
    return new Promise(
      (resolve) => 
        resolve($.get('api/usuarios/', { nome: nome }))
    );
  }

  salvar(usuario) {
    return new Promise(
      (resolve) => resolve($.post('/api/usuarios', usuario))
    );
  }

}