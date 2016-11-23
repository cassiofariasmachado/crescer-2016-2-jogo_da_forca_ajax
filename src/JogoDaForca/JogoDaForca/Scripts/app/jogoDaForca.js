let jogoDaForca = {};

jogoDaForca.renderizarTela = function (nome) {
    // escondendo todas as telas antes de renderizar a tela correta
    let $subTelas = $('.sub-tela');
    $.each($subTelas, (indice, elem) => $(elem).hide());
    let seletor = '';

    switch (nome) {
        case 'jogo':
            new TelaJogo('#tela-jogo');
            break;
        case 'inicial':
            new TelaInicial('#tela-inicial');
            break;
        case 'game-over':
            new TelaGameOver('#tela-game-over');
            break;
        case 'sucesso':
            new TelaSucesso('#tela-sucesso');
            break;
    }

};

jogoDaForca.loadTemplate = function (name) {

    return new Promise((resolve, reject) => {
        $.get(`/static/templates/${name}.tpl.html`).then(
          (template) => {
              resolve(Handlebars.compile(template));
          });
    });

};

jogoDaForca.render = function (viewElementSelector, templateName, data) {

    return new Promise((resolve, reject) => {
        this.loadTemplate(templateName).then(
         function (templateFn) {
             let rendered = templateFn(data);
             $(viewElementSelector).html(rendered);
             resolve();
         });
    });
};

jogoDaForca.iniciar = function () {
    return jogoDaForca.renderizarTela('inicial');
};

jogoDaForca.gerarPalavraCriptografada = function (palavra) {
    let palavraCriptografada = '';
    for (let i = 0, len = palavra.length; i < len; i++) {
        if(palavra[i] === ' ' || palavra[i] === '-') {
            palavraCriptografada += ' ';
        }
        else {
            palavraCriptografada += '-';
        }
    }
    return palavraCriptografada;
}

jogoDaForca.ehLetra = function (keyCode) {
    return keyCode >= 65 && keyCode <= 90 || keyCode === 186;
}

