let jogoDaForca = {};

jogoDaForca.renderizarTela = function (nome) {
    // escondendo todas as telas antes de renderizar a tela correta
    let $subTelas = $('.sub-tela');
    $.each($subTelas, (indice, elem) => $(elem).hide());
    let seletor = '';

    switch (nome) {
        case 'principal':
            new TelaPrincipal('#tela-principal', this.usuario, this.dificuldade);
            break;
        case 'inicial':
            new TelaInicial('#tela-inicial');
            break;
    }

};

jogoDaForca.loadTemplate = function (name) {

    return new Promise((resolve, reject) => {
        $.get(`/static/templates/${name}.tpl.html`).then(
          (template) => {
              resolve(Handlebars.compile(template));
          }
        )
    });

};

jogoDaForca.render = function (viewElementSelector, templateName, data) {

    return new Promise((resolve, reject) => {
        this.loadTemplate(templateName).then(
         function (templateFn) {
             let rendered = templateFn(data);
             $(viewElementSelector).html(rendered);
             resolve();
         }
       );
    });
};

jogoDaForca.iniciar = function () {
    return jogoDaForca.renderizarTela('inicial');
};

jogoDaForca.gerarPalavraCriptografada = function (tamanho) {
    let palavraCriptografada = '';
    for (let i = 0, len = tamanho; i < len; i++) {
        palavraCriptografada += '-';
    }
    return palavraCriptografada;
}

jogoDaForca.substituirLetra = function (palavra, palavraCriptografada, letra) {
    for (let i = 0, len = palavra.length; i < len; i++) {
        if (palavra[i] === letra) {
            palavraCriptografada = palavraCriptografada.replaceAt(i, letra);
        }
    }
    return palavraCriptografada;
}

jogoDaForca.ehLetra = function (keyCode) {
    return keyCode >= 65 && keyCode <= 90 || 186
}

