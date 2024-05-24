
import { UsuarioController } from "../../../Controllers/UsuarioController.js"

export class Usuario extends HTMLElement
{
    constructor()
    {
        super()
        this.render()
        this.fetch = new UsuarioController()
        this.registrarUsuario()
    }

    render = () => 
    {
        this.innerHTML = 
        `
            <div class="container w-100 d-flex justify-content-center">
                <div class="w-50 border border-3 rounded p-3 ">
                    <div class="text-center">
                        <h3>REGISTRAR USUARIO</h3>
                    </div>
                    <div id="mensajeError" class="text-center text-danger fw-semibold">
                        
                    </div>
                    <div id="mensajeExito" class="text-center text-success fw-semibold">
                        
                    </div>
                    <form id="formUsuario">
                        <div class="mb-3">
                        <label for="txtUsername" class="form-label">Username</label>
                        <input type="text" class="form-control" id="txtUsername">
                        </div>
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <input type="text" class="form-control" id="txtNombre">
                        </div>
                        <div class="mb-3">
                        <label for="txtPassword" class="form-label">Password</label>
                        <input type="password" class="form-control" id="txtPassword">
                        </div>
                        <div class="text-center">
                            <button type="submit" class="btn btn-success">ENVIAR</button>
                        </div>
                    </form>
                </div>
            </div>
        `
    }

    registrarUsuario()
    {
        const formUsuario = document.querySelector("#formUsuario")
        formUsuario.addEventListener("submit", event => 
        {
            event.preventDefault()

            let data = 
            {
                name    : document.querySelector("#txtName").value,
                username : document.querySelector("#txtUsername").value,
                password : document.querySelector("#txtPassword").value
            }

            const token = localStorage.getItem("token");

            fetch("http://localhost:5000/api/Usuarios/register",
            {
                method : "POST",
                headers : new Headers
                ({
                    "Content-Type":"application/json",
                    "Authorization": `Bearer ${token}`
                }),
                body : JSON.stringify(data)
            })
            .then(res => 
            { 
                return res.text()
            })
            .then(response => 
            {
                const mensajeError = document.querySelector("#mensajeError")
                const mensajeExito = document.querySelector("#mensajeExito")

                if(response == `El usuario con ${data.username} ya se encuentra registrado.`)
                {
                    mensajeExito.innerHTML = ""
                   mensajeError.innerHTML = `${response}`
                } else
                {
                    mensajeError.innerHTML = ""
                    mensajeExito.innerHTML = `${response}`
                    formUsuario.reset()
                }

            })
            .catch(error => console.log(error))
        })
    }
}
customElements.define("registrar-usuario", Usuario)