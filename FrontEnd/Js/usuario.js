import { UsuarioController } from "../Controllers/UsuarioController.js";

const fetch = new UsuarioController()

const formInicioSesion = document.querySelector("#inicioSesion")

formInicioSesion.addEventListener("submit", event => 
{
    event.preventDefault()

    const data = 
    {
        username : document.querySelector("#txtUsername").value,
        password : document.querySelector("#txtPassword").value,
    }

    fetch.controllerUsuarioToken(data)
    .then(res => 
    {
        let token = res.token
        localStorage.setItem('token', token)
        location.href = "home.html"
    })
    .catch(error => {
        console.log(error)
    })
})