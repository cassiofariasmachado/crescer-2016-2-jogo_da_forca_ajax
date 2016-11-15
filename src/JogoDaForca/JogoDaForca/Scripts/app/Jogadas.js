class Jogadas {

     pegarRegistros(pagina, qtdJogadasPorPagina) {
        return $.get('/api/jogadas', {
            pagina: pagina,
            tamanhoPagina: qtdJogadasPorPagina
       });
    }
    
    cadastrar(jogada) {
      return $.post('/api/jogadas', jogada);
    }