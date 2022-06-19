window.NavegarPara = (rota) => {
    document.location.href = rota;
    return;
}

window.SaveToSessionStorage = (chave, valor) => {
    //window.localStorage.setItem(chave, valor);
    window.sessionStorage.setItem(chave, valor);   
    return;
}

window.GetFromSessionStorage = (chave) => {
    //var valor = window.localStorage.getItem(chave);
    var valor = window.sessionStorage.getItem(chave);
    return valor;
}

window.DestroyFromSessionStorage = (chave) => {
    //window.localStorage.removeItem(chave);
    window.sessionStorage.removeItem(chave);
    return;
}