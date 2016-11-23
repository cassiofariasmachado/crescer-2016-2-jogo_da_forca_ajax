Storage.prototype.setObject = function (chave, objeto) {
    this.setItem(chave, JSON.stringify(objeto))
}

Storage.prototype.getObject = function (chave) {
    return JSON.parse(this.getItem(chave));
}