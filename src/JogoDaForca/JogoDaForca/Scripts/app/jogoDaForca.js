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
    if (palavra[i] === letra) {
      palavraCriptografada = palavraCriptografada.replaceAt(i, letra);
    }
  }
  return palavraCriptografada;
}

jogoDaForca.ehLetra = function (keyCode) {
  return keyCode >= 65 && keyCode <= 90
}

jogoDaForca.atualizarPalavra = function (novaPalavra) {
  $('#palavra').text(novaPalavra)
}

jogoDaForca.atualizarTentativas = function (tentativas) {
  $('#tentativas').text(tentativas)
}

jogoDaForca.atualizarTentativasErradas = function (tentativasErradas) {
  $('#tentativas-erradas').text(tentativasErradas)
}

jogoDaForca.modoBh = function () {
    if (palavra.contains(letra)) {
        palavraCriptografada = jogoDaForca.substituirLetra(palavra, palavraCriptografada, letra);
        jogoDaForca.atualizarPalavra(palavraCriptografada);
    }
    else {
        tentativasErradas++;
        jogoDaForca.atualizarTentativasErradas(tentativasErradas);
    }
    tentativas++;
    jogoDaForca.atualizarTentativas(tentativas);
    if (tentativasErradas > 2) {
        return 'Game over';
    }
}

jogoDaForca.modoNormal = function(){
	              if (palavra.contains(letra)) {
                  palavraCriptografada = jogoDaForca.substituirLetra(palavra, palavraCriptografada, letra);
                  jogoDaForca.atualizarPalavra(palavraCriptografada);
              }
              else {
                  tentativasErradas++;
                  jogoDaForca.atualizarTentativasErradas(tentativasErradas);
              }
              tentativas++;
              jogoDaForca.atualizarTentativas(tentativas);
              if (tentativasErradas > 5) {
                  return 'Game over';
              }
}

jogoDaForca.iniciarJogo = function (modo) {
  let palavras = new Palavras();
  palavras.pegarPalavraAleatoria(modo).then(
    res => {
      let palavra = res.vocabulo.toLocaleUpperCase();
      let palavraCriptografada = jogoDaForca.gerarPalavraCriptografada(palavra.length);
      let pontuacao = 0;
      let tentativas = 0;
      let tentativasErradas = 0;

      jogoDaForca.atualizarPalavra(palavraCriptografada);
      jogoDaForca.atualizarTentativas(tentativas);

      $("#letra").keydown(function (event) {
        if (jogoDaForca.ehLetra(event.keyCode)) {
          let letra = event.key.toLocaleUpperCase();
          if (modo === 'normal') {
				jogoDaForca.modoNormal();
          } else if (modo === 'bh') {
			  setInterval(jogoDaForca.modoBh, 20000);
          }
          if (!palavraCriptografada.contains('-')) {
              pontuacao++;
              return 'Rodada completa'
          }
        }
      });


    }
  );
}
