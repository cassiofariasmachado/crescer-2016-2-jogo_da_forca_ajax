class Leaderboards{

    pegarRegistros(pagina, qtdJogadasPorPagina) {
        return $.get('/api/jogadas', {
            pagina: pagina,
            tamanhoPagina: qtdJogadasPorPagina
        });
    }

    salvar(jogada) {
        return $.post('/api/jogadas', jogada);
    }
}