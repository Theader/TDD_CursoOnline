function formQuandoFalha(erro){
    if (erro.Status == 500) {
        toastr.error(erro.responseText);
    }
    else if (erro.Status == 502) {
        erro.ResponseJSON.forEach(function (mensagemDeErro) {
            toastr.error(mensagemDeErro);
        })
    }
}