const register = () => {
    let nome = document.getElementById('register_nome').value
    let email = document.getElementById('register_email').value
    let senha = document.getElementById('register_senha').value

    postAsync({ nome, email, senha }, "http://localhost:5238/api/v1/User")
        .then((response) => {
            alert("Registrado com sucesso")
            clearData()
            loginScreen()
        }).catch((error) => {
            console.log(error)
        })
}

const clearData = () => {
    document.getElementById('register_nome').value = ""
    document.getElementById('register_email').value = ""
    document.getElementById('register_senha').value = ""
}