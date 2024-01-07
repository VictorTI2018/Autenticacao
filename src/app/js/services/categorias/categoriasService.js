const cadastrarCategoria = () => {
    let nome = document.getElementById('categorias_nome').value
    let descricao = document.getElementById('categorias_descricao').value

    postAsync({
        nome,
        descricao
    }, "http://localhost:5238/api/v1/Categorias").then((response) => {
        console.log(response)
    }).catch((err) => {
        console.error(err)
    })
}