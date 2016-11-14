class Usuario {

  buscarUsuarioPorId(id) {
    return new Promise(
      (resolve, reject) => resolve($.get('api/usuarios/' + id))
    );
  }

  salvar(usuario) {
    return new Promise(
      (resolve, reject) => resolve($.post('/api/usuarios', usuario))
    );
  }

}