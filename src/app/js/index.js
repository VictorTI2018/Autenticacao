function registerScreen() {
    var login = document.getElementById('login')
    var register = document.getElementById('register')
    login.style.display = "none"
    register.style.display = "block"
}

function loginScreen () {
    var login = document.getElementById('login')
    var register = document.getElementById('register')
    register.style.display = "none"
    login.style.display = "block"
}

const init = () => {
    var register = document.getElementById('register')
    register.style.display = "none"

    var isAuthenticate = JSON.parse(localStorage.getItem("token"))

    if (isAuthenticate) {
        var login = document.getElementById('login')
        register.style.display = "none"
        login.style.display = "none"
    }
        
}

init()