class TelaInicial {
  
  constructor(seletor) {
    this.$elem = $(seletor);
    this.usuarios = new Usuarios();
    this.registrarBindsEventos();
    this.renderizarEstadoInicial();
  }

  registrarBindsEventos() {
    this.$formUsuario = $('#form-usuario');
    this.$usuario = $('#usuario');
    this.$dificuldade = $('#dificuldade');
    this.$btnSubmit = this.$formUsuario.find('button[type=submit]');
    let self = this;

    let validator = this.$formUsuario.validate({
      highlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').addClass('has-error');
      },
      unhighlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').removeClass('has-error');
      },
      showErrors: function () {
        if (validator.numberOfInvalids() === 0) {
          self.$btnSubmit.removeAttr('disabled');
        } else {
          self.$btnSubmit.attr('disabled', true);
        }
        this.defaultShowErrors();
      },
      submitHandler: function () {
        self.$btnSubmit.text('Carregando...');
        self.$btnSubmit.attr('disabled', true);
        setTimeout(function () {
            self.usuario;
            self.dificuldade = self.$dificuldade.val();
            let nome = self.$usuario.val();
            self.usuarios.buscarUsuario(nome)
                         .then(res => {
                                        self.usuario = res;
                                        jogoDaForca.renderizarTela.call(self, 'principal');
                                      })
                         .catch(rej => {    
                                          console.log('Usuario não encontrado, será cadastrado um novo.')
                                          self.usuarios.salvar({nome: nome} )
                                                       .then(res => {
                                                                      self.usuario = res;
                                                                      jogoDaForca.renderizarTela.call(self, 'principal');
                                                                    }); 
                                      });
          }, 1000);
      }
    });
  }

  renderizarEstadoInicial() {
    this.$elem.show();
    this.$btnSubmit.attr('disabled', !this.$formUsuario.valid());
  }

}