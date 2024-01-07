'use strict'

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

(function () {
    
const init = () => {
    var register = document.getElementById('register')
    register.style.display = "none"

    var isAuthenticate = JSON.parse(localStorage.getItem("token"))

    if (isAuthenticate) {
        var login = document.getElementById('login')
        var app = document.getElementById('app')

        register.style.display = "none"
        login.style.display = "none"

        app.style.display = 'block'
        app.style.padding = '10px 20px'
        
        var router = new Router([
            new Route('home', 'categorias.html', true)
        ])

        console.log(router)
    }
}

init()
}())