let jogoDaForca = {};

jogoDaForca.renderizarTela = function (nome) {

  // escondendo todas as telas antes de renderizar a tela correta
  let $subTelas = $('.sub-tela');
  $.each($subTelas, (indice, elem) => $(elem).hide());
  let seletor = '';

  switch (nome) {
    case 'principal':
      new TelaPrincipal('#tela-principal', this);
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
    if (palavra[i].toLocaleUpperCase() === letra.toLocaleUpperCase()) {
      palavraCriptografada = palavraCriptografada.replaceAt(i, letra.toLocaleUpperCase());
    }
  }
  return palavraCriptografada;
}

jogoDaForca.atualizarPalavra = function (novaPalavra) {
  $('#palavra').text(novaPalavra)
}

jogoDaForca.atualizarTentativas = function (tentativa) {
  $('#tentativa').text(tentativa)
}

jogoDaForca.iniciarJogo = function () {
  let palavras = new Palavras();
  palavras.pegarPalavraAleatoria().done(
    res => {
      let palavra = res.vocabulo;
      let palavraCriptografada = jogoDaForca.gerarPalavraCriptografada(palavra.length);
      let tentativa = 0;
      jogoDaForca.atualizarPalavra(palavraCriptografada);
      jogoDaForca.atualizarTentativas(tentativa);
      let letra = $("#letra").keydown(function (event) {
        if (event.keyCode > 64 && event.keyCode < 91) {
          palavraCriptografada = jogoDaForca.substituirLetra(palavra, palavraCriptografada, event.key);
          tentativa++;
          jogoDaForca.atualizarPalavra(palavraCriptografada);
          jogoDaForca.atualizarTentativas(tentativa);
        }
      });


    }
  );
}
