const authenticate = () => {
    let email = document.getElementById('login_email').value
    let senha = document.getElementById('login_senha').value

    postAsync({ email, senha }, "http://localhost:5238/api/v1/Auth")
    .then((response) => {
        console.log(response)
        localStorage.setItem("token", JSON.stringify(response))
        window.location.reload()
    }).catch((error) => {
        console.log(error)
    })
}