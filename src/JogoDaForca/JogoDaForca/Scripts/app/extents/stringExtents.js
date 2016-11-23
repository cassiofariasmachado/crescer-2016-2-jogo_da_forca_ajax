String.prototype.replaceAt = function (index, character) {
  return this.substr(0, index) + character + this.substr(index + character.length);
}

String.prototype.contains = function (palavra) {
  let indice = this.trim().indexOf(palavra);
  return indice >= 0;
}